using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.ModelViews
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}
