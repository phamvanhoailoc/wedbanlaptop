using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var taikhoanID = HttpContext.Session.GetString("Id");
            if (taikhoanID != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login", "AdminTaiKhoans");
            }
        }
    }
}
