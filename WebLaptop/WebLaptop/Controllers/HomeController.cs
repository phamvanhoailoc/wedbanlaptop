using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebLaptop.Models;
using WebLaptop.ModelViews;

namespace WebLaptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbShopLaptopContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbShopLaptopContext context)
        {
            _logger = logger;
            _context = context;
        }       
        public IActionResult Index()
        {
            HomeViewVM model = new HomeViewVM();

            var IsBestsell = _context.Products
                      .AsNoTracking()
                      .Where(x => x.BestSeller && x.BestSeller == true)
                      .OrderByDescending(x => x.DateCreated)
                      .ToList();

            var IsnewProduct = _context.Products
                     .AsNoTracking()
                     .Where(x => x.HomeFlag == true)
                     .OrderByDescending(x => x.DateCreated)
                     .ToList();


            var Tintuc = _context.Tintucs
                .AsNoTracking()
                .Where(x => x.Published == true && x.IsNewfeed == true)
                .OrderByDescending(x => x.CreateDate)
                .Take(6)
                .ToList();
            var categoris = _context.Categories
               .AsNoTracking()
               .Where(x => x.Published == true )
               .OrderByDescending(x => x.CatId)
               .ToList();
            model.Products = IsBestsell;
            model.TinTucs = Tintuc;
            model.Categories = categoris;
            ViewBag.Allproduct = IsnewProduct;
            return View(model);
        }

        [Route("Lien-he.html", Name = "Liên hệ")]
        public IActionResult Contact()
        {
           
            return View();
        }

        [Route("Ve-chung-toi.html", Name = "Về chúng tôi")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
