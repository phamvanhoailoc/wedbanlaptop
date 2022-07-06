using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Extension;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebLaptop.Models;
using WebLaptop.ModelViews;

namespace WebLaptop.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public AccountsController(DbShopLaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var khachhang = _context.Khachhangs
                    .AsNoTracking()
                    .SingleOrDefault(x => x.Sdt.ToLower() == Phone.ToLower());
                if (khachhang != null)
                    return Json(data: "Số điện thoại: " + Phone + "Đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var khachhang = _context.Khachhangs
                    .AsNoTracking()
                    .SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (khachhang != null)
                    return Json(data: "Email: " + Email + "Đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }
        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        { 
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));             
                if (khachhang != null)
                {
                    var IsDonHang = _context.Orders
                        .AsNoTracking()
                        .Where(x => x.Id == khachhang.Id ) 
                        .OrderByDescending(x => x.OrderDate).ToList();
                    ViewBag.DonHang = IsDonHang;
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login");
        }

        [Route("don-hang-cua-toi.html", Name = "Danh Sách Đơn Hàng")]
        public IActionResult ListOrder()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var IsDonHang = _context.Orders
                        .AsNoTracking()
                        .Where(x => x.KhachhangId == khachhang.Id)
                        .OrderByDescending(x => x.OrderDate).ToList();
                    ViewBag.DonHang = IsDonHang;                  
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html",Name ="DangKy")]
        public IActionResult DangKyTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> DangKyTaiKhoan(RegisterVM taikhoan)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    Khachhang khachhang = new Khachhang
                    {
                        FullName = taikhoan.FullName,
                        Sdt = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Matkhau = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Active = true,
                        Salt = salt,
                        CreateDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        // lưu Session makh
                        HttpContext.Session.SetString("Id", khachhang.Id.ToString());
                        var taikhoanID = HttpContext.Session.GetString("Id");
                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.FullName),
                            new Claim("Id",khachhang.Id.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    catch(Exception ex)
                    {
                        return RedirectToAction("DangKyTaiKhoan", "Accounts");
                    }
                }
                else
                {
                    return View(taikhoan);
            }
            }
            catch
            {
                return View(taikhoan);
            }          
        }
  
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);
                    var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (khachhang == null) return RedirectToAction("DangKyTaiKhoan");
                    string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                    if(khachhang.Matkhau != pass)
                    {
                        _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                        return View(customer);
                    }
                    //kiem tra active
                    if (khachhang.Active == false) return RedirectToAction("ThongBao", "Accounts");
                    //luu session
                    HttpContext.Session.SetString("Id", khachhang.Id.ToString());
                    var taikhoanID = HttpContext.Session.GetString("Id");
                    //identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("Id",khachhang.Id.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    return RedirectToAction("Dashboard", "Accounts");
                }
            }
            catch 
            {
                return RedirectToAction("DangKyTaiKhoan", "Accounts");
            }
            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat.html",Name ="Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Index", "Home");
        }
    
        [AllowAnonymous]
        [Route("doi-mat-khau.html", Name = "ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("doi-mat-khau.html", Name = "ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("Id");
                if (taikhoanID == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Khachhangs.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("Login", "Accounts");
                    var pass = (model.PasswordNow.Trim() + taikhoan.Salt.Trim()).ToMD5();
                    if (pass == taikhoan.Matkhau)
                    {
                        string passnew = (model.Password.Trim() + taikhoan.Salt.Trim()).ToMD5();
                        taikhoan.Matkhau = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Đổi mật khẩu thành công");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                }
          
            }
            catch
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            _notyfService.Success("Đổi mật khẩu thất bại");
            return RedirectToAction("Dashboard", "Accounts");
        }


    }
}
