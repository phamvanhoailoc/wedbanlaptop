using AspNetCoreHero.ToastNotification.Abstractions;
using BraintreeHttp;
using DiChoSaiGon.Extension;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;
using WebLaptop.ModelViews;
using Order = WebLaptop.Models.Order;

namespace WebLaptop.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }
        private readonly string _clientId;
        private readonly string _secretKey;

        public double TyGIaUSD = 23300;
        

        public CheckoutController(DbShopLaptopContext context, INotyfService notyfService, IConfiguration config)
        {
            _context = context;
            _notyfService = notyfService;
            _clientId = config["PaypalSettings:ClientId"];
            _secretKey = config["PaypalSettings:SecretKey"];
        }
        [Route("checkout.html", Name ="Checkout")]
        public IActionResult Index(string returnUrl = null)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("Id");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.Diachi;
            }
            ViewBag.GioHang = cart;
            return View(model);
        }
        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("Id");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.Diachi;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Order donhang = new Order();
                    donhang.KhachhangId = model.CustomerId;
                    donhang.Address = model.Address;
                    donhang.OrderDate = DateTime.Now;
                    donhang.TransacStatusId = 1;
                    donhang.Delete = false;
                    donhang.Paid = false;
                    donhang.Note = Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();


                    foreach (var item in cart)
                    {
                        ChitietOrder chitietOrder = new ChitietOrder();
                        chitietOrder.OrderId = donhang.Id;
                        chitietOrder.ProductId = item.product.Id;
                        chitietOrder.Amount = item.amount;
                        chitietOrder.Total = donhang.TotalMoney;
                        chitietOrder.CreateDate = DateTime.Now;
                        _context.Add(chitietOrder);
                    }
                    _context.SaveChanges();
                    HttpContext.Session.Remove("GioHang");
                    _notyfService.Success("Đơn hàng đặt thành công");
                    return RedirectToAction("Success");
                }
            }
            catch (Exception)
            {

                ViewBag.GioHang = cart;
                return View(model);
            }
            ViewBag.GioHang = cart;
            return View(model);
        }
        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            return View();
                                
        }
        public async Task<IActionResult> PaypalCheckout()
        {
            var Carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);
            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = Math.Round(Carts.Sum(p => p.TotalMoney) / TyGIaUSD, 2);
            foreach (var item in Carts)
            {
                itemList.Items.Add(new Item()
                { 
                    Name = item.product.ProducName,
                    Currency = "USD",
                    Price = Math.Round((double)item.product.Price / TyGIaUSD, 2).ToString(),
                    Quantity = item.amount.ToString(),
                    Sku = "sku",
                    Tax = "0"
                }) ;
            }
            #endregion
            var paypalOrderId = DateTime.Now.Ticks;
            var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{hostname}/Checkout/CheckoutFail",
                    ReturnUrl = $"{hostname}/Checkout/CheckoutSuccess"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };
            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //Process when Checkout with Paypal fails
                return Redirect("/Checkout/CheckoutFail");
            }

        }
        public IActionResult CheckoutFail()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("Id");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.Diachi;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Order donhang = new Order();
                    donhang.KhachhangId = model.CustomerId;
                    donhang.Address = model.Address;
                    donhang.OrderDate = DateTime.Now;
                    donhang.TransacStatusId = 1;
                    donhang.Delete = false;
                    donhang.Paid = false;
                    donhang.Note = Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();


                    foreach (var item in cart)
                    {
                        ChitietOrder chitietOrder = new ChitietOrder();
                        chitietOrder.OrderId = donhang.Id;
                        chitietOrder.ProductId = item.product.Id;
                        chitietOrder.Amount = item.amount;
                        chitietOrder.Total = donhang.TotalMoney;
                        chitietOrder.CreateDate = DateTime.Now;
                        _context.Add(chitietOrder);
                    }
                    _context.SaveChanges();
                    HttpContext.Session.Remove("GioHang");
                    _notyfService.Success("Đơn hàng đặt thành công");
                    return RedirectToAction("Success");
                }
            }
            catch (Exception)
            {

                ViewBag.GioHang = cart;
                return View(model);
            }
            ViewBag.GioHang = cart;
            return View(model);
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Chưa thanh toán"
            //Xóa session         
        }

        public IActionResult CheckoutSuccess()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("Id");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.FullName;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sdt;
                model.Address = khachhang.Diachi;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Order donhang = new Order();
                    donhang.KhachhangId = model.CustomerId;
                    donhang.Address = model.Address;
                    donhang.OrderDate = DateTime.Now;
                    donhang.TransacStatusId = 1;
                    donhang.Delete = false;
                    donhang.Paid = true;
                    donhang.Note = Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();


                    foreach (var item in cart)
                    {
                        ChitietOrder chitietOrder = new ChitietOrder();
                        chitietOrder.OrderId = donhang.Id;
                        chitietOrder.ProductId = item.product.Id;
                        chitietOrder.Amount = item.amount;
                        chitietOrder.Total = donhang.TotalMoney;
                        chitietOrder.CreateDate = DateTime.Now;
                        _context.Add(chitietOrder);
                    }
                    _context.SaveChanges();
                    HttpContext.Session.Remove("GioHang");
                    _notyfService.Success("Thanh toán thành công");
                    return RedirectToAction("Success");
                }
            }
            catch (Exception)
            {

                ViewBag.GioHang = cart;
                return View(model);
            }
            ViewBag.GioHang = cart;
            return View(model);
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            //Xóa session          
        }
    }
}
