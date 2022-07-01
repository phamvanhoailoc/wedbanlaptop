using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly DbShopLaptopContext _context;

        public SearchController(DbShopLaptopContext context)
        {
            _context = context;
        }
        //GET: Search/FindProduct
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
           List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductSearchPartialView", null);
            }
             ls = _context.Products
                                        .AsNoTracking()
                                        .Include(a => a.Cat)
                                        .Where(x => x.ProducName.Contains(keyword))
                                        .OrderByDescending(x => x.ProducName)
                                        .Take(10)
                                        .ToList();
            if (ls == null)
            {
                return PartialView("ListProductSearchPartialView", null);
            }
            else
            {
                return PartialView("ListProductSearchPartialView", ls);
            }
        }
    }
}
