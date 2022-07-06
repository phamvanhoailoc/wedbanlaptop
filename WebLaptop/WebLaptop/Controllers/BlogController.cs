using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.Controllers
{
    public class BlogController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public BlogController(DbShopLaptopContext context)
        {
            _context = context;
        }
        [Route("blogs.html", Name = "Blog")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var Istintucs = _context.Tintucs
                .AsNoTracking()
                .OrderByDescending(x => x.Id);
            PagedList<Tintuc> models = new PagedList<Tintuc>(Istintucs, pageNumber, pageSize);
            var IsBestsell = _context.Tintucs
                    .AsNoTracking()
                    .Where(x => x.IsHot && x.IsHot == true)
                    .OrderByDescending(x => x.CreateDate)
                    .Take(4)
                    .ToList();
            ViewBag.BestSell = IsBestsell;
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        [Route("/tin-tuc/{Alias}-{id}.html", Name = "TinDetails")]
        public IActionResult Details(int id)
        {
            var Tintuc = _context.Tintucs.AsNoTracking().SingleOrDefault(x => x.Id == id);
            if (Tintuc == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaivietlienquan = _context.Tintucs
               .AsNoTracking()
               .Where(x => x.Published == true && x.Id != id)
               .Take(3).OrderByDescending(x => x.CreateDate)
               .ToList();

            var IsBestsell = _context.Tintucs
                    .AsNoTracking()
                    .Where(x => x.IsHot && x.IsHot == true)
                    .OrderByDescending(x => x.CreateDate)
                    .Take(4)
                    .ToList();
            ViewBag.BestSell = IsBestsell;
            ViewBag.Baivietlienquan = lsBaivietlienquan;
            return View(Tintuc); ;
        }
    }
}
