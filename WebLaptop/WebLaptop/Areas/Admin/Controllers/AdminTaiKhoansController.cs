using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Extension;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLaptop.Areas.Admin.ModelViews;
using WebLaptop.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTaiKhoansController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public AdminTaiKhoansController(DbShopLaptopContext context, INotyfService notyfService)
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
                var taikhoan = _context.TaiKhoans
                    .AsNoTracking()
                    .SingleOrDefault(x => x.Sdt.ToLower() == Phone.ToLower());
                if (taikhoan != null)
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
                var taikhoan = _context.TaiKhoans
                    .AsNoTracking()
                    .SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (taikhoan != null)
                    return Json(data: "Email: " + Email + "Đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }


        // GET: Admin/AdminTaiKhoans
        public async Task<IActionResult> Index()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Desciption");
                List<SelectListItem> IsTrangThai = new List<SelectListItem>();
                IsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
                IsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "0" });
                ViewData["IsTrangThai"] = IsTrangThai;
                var dbShopLaptopContext = _context.TaiKhoans.Include(t => t.Role);
                return View(await dbShopLaptopContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }
            
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Login", "AdminTaiKhoans");
        }

        // GET: Admin/AdminTaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // GET: Admin/AdminTaiKhoans/Create
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null) {
                return View();

            } else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }             
        }

        // POST: Admin/AdminTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(RegisterAdminVM taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    TaiKhoan tk = new TaiKhoan
                    {
                        Ten = taikhoan.FullName,
                        Sdt = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Matkhau = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Trangthai = true,
                        RoleId = 1,
                        Salt = salt,
                        Createlogin = DateTime.Now
                    };
                    try
                    {
                        _context.Add(tk);
                        await _context.SaveChangesAsync();
                        // lưu Session makh
                        HttpContext.Session.SetString("Id", tk.Id.ToString());
                        var taikhoanID = HttpContext.Session.GetString("Id");
                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,tk.Ten),
                            new Claim("Id",tk.Id.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng ký thành công");
                        return RedirectToAction("Index", "AdminTaiKhoans");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Create", "AdminTaiKhoans");
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
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                return RedirectToAction("Index", "AdminTaiKhoans");
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginAdminViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);
                    var taikhoan = _context.TaiKhoans.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (taikhoan == null) return RedirectToAction("Create");
                    string pass = (customer.Password + taikhoan.Salt.Trim()).ToMD5();
                    if (taikhoan.Matkhau != pass)
                    {
                        _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                        return View(customer);
                    }
                    //kiem tra active
                    if (taikhoan.Trangthai == false) return RedirectToAction("ThongBao", "Accounts");
                    //luu session
                    HttpContext.Session.SetString("Id", taikhoan.Id.ToString());
                    var taikhoanID = HttpContext.Session.GetString("Id");
                    //identity
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, taikhoan.Ten),
                        new Claim("Id",taikhoan.Id.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    return RedirectToAction("Index", "AdminTaiKhoans");
                }
            }
            catch
            {
                return RedirectToAction("Index", "AdminTaiKhoans");
            }
            return View(customer);
        }

        // GET: Admin/AdminTaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", taiKhoan.RoleId);
            return View(taiKhoan);
        }

        // POST: Admin/AdminTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sdt,Email,Matkhau,Trangthai,Ten,RoleId,Lastlogin,Createlogin,Salt")] TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", taiKhoan.RoleId);
            return View(taiKhoan);
        }

        // GET: Admin/AdminTaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // POST: Admin/AdminTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoans.Any(e => e.Id == id);
        }
    }
}
