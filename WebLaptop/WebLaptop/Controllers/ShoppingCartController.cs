using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Extension;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;
using WebLaptop.ModelViews;

namespace WebLaptop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public ShoppingCartController(DbShopLaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddCart(int productID, int? amount)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                CartItem item = GioHang.SingleOrDefault(p => p.product.Id == productID);
                
                if (item!= null)
                {
                    if (amount.HasValue)
                    {
                        item.amount = amount.Value;
                        HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                    }
                    else
                    {
                        item.amount++;
                    }
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.Id == productID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        product = hh
                    };
                    gioHang.Add(item);//them gio hang
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch 
            {

                return Json(new { success = false });
            }
          
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {               
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.product.Id == productID);
                    if (item != null && amount.HasValue)
                    {
                        item.amount =  amount.Value;
                        HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                    }                            
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                return Json(new { success = true });
            }
            catch
            {

                return Json(new { success = false });
            }

        }

        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult Remove(int productID)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                CartItem item = gioHang.SingleOrDefault(p => p.product.Id == productID);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch 
            {

                return Json(new { success = false });
            }
        }
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(GioHang);
        }
    }
}
