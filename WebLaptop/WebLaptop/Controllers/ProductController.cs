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
    public class ProductController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public ProductController(DbShopLaptopContext context)
        {
            _context = context;
        }
        [Route("shop.html", Name = "ShopProduct")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 12;
                var IsProducts = _context.Products
                    .AsNoTracking()
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(IsProducts, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                var IsBestsell = _context.Products
                    .AsNoTracking()
                    .Where(x=>x.BestSeller && x.BestSeller == true)
                    .OrderByDescending(x=>x.DateCreated)
                    .Take(4)
                    .ToList();
                ViewBag.BestSell = IsBestsell;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        [Route("/{Alias}", Name = "ListProduct")]
        public IActionResult List(string Alias ,int page=1)
        {
            try
            {
                var pageSize = 4;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var IsProducts = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == danhmuc.CatId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(IsProducts, page, pageSize);
                var IsBestsell = _context.Products
                    .AsNoTracking()
                    .Where(x => x.BestSeller && x.BestSeller == true)
                    .OrderByDescending(x => x.DateCreated)
                    .Take(4)
                    .ToList();
                ViewBag.BestSell = IsBestsell;
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
        [Route("/{Alias}-{id}.html",Name ="ProductDetails")]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                var IsProduct = _context.Products
                   .AsNoTracking()
                   .Where(x => x.CatId == product.CatId && x.Id != id && x.Active == true)
                   .OrderByDescending(x => x.DateCreated)
                   .Take(4)
                   .ToList();
                ViewBag.sanpham = IsProduct;
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}
