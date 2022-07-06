using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;
using WebLaptop.ModelViews;

namespace WebLaptop.Controllers
{
    public class DonHangController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public DonHangController(DbShopLaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        


        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("Id");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang == null) return NotFound();
                var donhang = await _context.Orders
                    .Include(x => x.TransacStatus)
                    .FirstOrDefaultAsync(m => m.Id == id && Convert.ToInt32(taikhoanID) == m.KhachhangId);
                if (donhang == null)
                {
                    return NotFound();
                }
                var chitietdonhang = _context.ChitietOrders
                    .Include(x => x.Product)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.Id)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("Details", donHang);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
