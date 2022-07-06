using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using DiChoSaiGon.Helpper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebLaptop.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTintucsController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public INotyfService _notyfService { get; }

        public AdminTintucsController(DbShopLaptopContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminTintucs
        public IActionResult Index(int? page)
        {

            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 20;
                var Istintucs = _context.Tintucs
                    .AsNoTracking()
                    .OrderByDescending(x => x.Id);
                PagedList<Tintuc> models = new PagedList<Tintuc>(Istintucs, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);

            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }
           
        }

        // GET: Admin/AdminTintucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .Include(t => t.Account)
                .Include(t => t.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Create
        public IActionResult Create()
        {
            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                ViewData["AccountId"] = new SelectList(_context.TaiKhoans, "Id", "Id");
                ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId");
                return View();

            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }

           
        }

        // POST: Admin/AdminTintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Scontent,Contact,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] Tintuc tintuc, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
               
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageName = Utilities.SEOUrl(tintuc.Title) + extension;
                    tintuc.Thumb = await Utilities.UploadFile(fThumb, @"tintuc", imageName.ToLower());
                }
                if (string.IsNullOrEmpty(tintuc.Thumb)) tintuc.Thumb = "default.jpg";
                tintuc.CreateDate = DateTime.Now;
                _context.Add(tintuc);
                _notyfService.Success("Create thành công");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.TaiKhoans, "Id", "Id", tintuc.AccountId);
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", tintuc.CatId);
            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.TaiKhoans, "Id", "Id", tintuc.AccountId);
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", tintuc.CatId);
            return View(tintuc);
        }

        // POST: Admin/AdminTintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Scontent,Contact,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] Tintuc tintuc, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != tintuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string imageName = Utilities.SEOUrl(tintuc.Title) + extension;
                        tintuc.Thumb = await Utilities.UploadFile(fThumb, @"tintuc", imageName.ToLower());
                    }
                    if (string.IsNullOrEmpty(tintuc.Thumb)) tintuc.Thumb = "default.jpg";
                    tintuc.CreateDate = DateTime.Now;
                    _context.Update(tintuc);
                    _notyfService.Success("cập nhật thành công");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.Id))
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
            ViewData["AccountId"] = new SelectList(_context.TaiKhoans, "Id", "Id", tintuc.AccountId);
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId", tintuc.CatId);
            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .Include(t => t.Account)
                .Include(t => t.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: Admin/AdminTintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tintuc = await _context.Tintucs.FindAsync(id);
            _context.Tintucs.Remove(tintuc);
            _notyfService.Success("Xóa thành công");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
            return _context.Tintucs.Any(e => e.Id == id);
        }
    }
}
