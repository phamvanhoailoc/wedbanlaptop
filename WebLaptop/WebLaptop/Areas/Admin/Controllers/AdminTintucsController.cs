using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AdminTintucsController(DbShopLaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminTintucs
        public IActionResult Index(int? page)
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
            ViewData["AccountId"] = new SelectList(_context.TaiKhoans, "Id", "Id");
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId");
            return View();
        }

        // POST: Admin/AdminTintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Scontent,Contact,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tintuc);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Scontent,Contact,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] Tintuc tintuc)
        {
            if (id != tintuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tintuc);
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
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
            return _context.Tintucs.Any(e => e.Id == id);
        }
    }
}
