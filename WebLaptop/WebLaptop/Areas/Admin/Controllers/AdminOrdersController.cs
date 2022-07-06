using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebLaptop.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public AdminOrdersController(DbShopLaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminOrders
        public IActionResult Index(int page = 1)
        {

            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                var pageNumber = page;
                var pageSize = 8;

                var IsOrder = _context.Orders.Include(x => x.Khachhang).Include(x => x.TransacStatus)
                     .AsNoTracking()
                     .OrderByDescending(x => x.OrderDate);

                PagedList<Order> models = new PagedList<Order>(IsOrder.AsQueryable(), pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;

                return View(models);

            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }

           
        }


        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                
                .Include(o => o.Khachhang)
                .Include(o => o.TransacStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var chitietdonhang = _context.ChitietOrders
                .Include(x=> x.Product)
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .OrderBy(x => x.Id)
                .ToList();
            ViewBag.chitiet = chitietdonhang;
            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "Id", "Id");
                ViewData["TransacStatusId"] = new SelectList(_context.TransacStatuses, "Id", "Status");
                return View();

            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }

           
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KhachhangId,OrderDate,ShipDate,TransacStatusId,Delete,Paid,PaymentDate,PaymentId,Note,TotalMoney,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "Id", "Id", order.KhachhangId);
            ViewData["TransacStatusId"] = new SelectList(_context.TransacStatuses, "Id", "Status", order.TransacStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "Id", "Id", order.KhachhangId);
            ViewData["TransacStatusId"] = new SelectList(_context.TransacStatuses, "Id", "Status", order.TransacStatusId);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KhachhangId,OrderDate,ShipDate,TransacStatusId,Delete,Paid,PaymentDate,PaymentId,Note,TotalMoney,Address")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var donhang = await _context.Orders.AsNoTracking().Include(o => o.Khachhang).Include(o => o.TransacStatus).FirstOrDefaultAsync(m => m.Id == id);
                    
                    _context.Update(donhang);               
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Edit thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "Id", "Id", order.KhachhangId);
            ViewData["TransacStatusId"] = new SelectList(_context.TransacStatuses, "Id", "Status", order.TransacStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Khachhang)
                .Include(o => o.TransacStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
