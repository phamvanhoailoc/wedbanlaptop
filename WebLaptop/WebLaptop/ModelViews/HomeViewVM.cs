using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.ModelViews
{
    public class HomeViewVM
    {
        public List<Tintuc> TinTucs { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
