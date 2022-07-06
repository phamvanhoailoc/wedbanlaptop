using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.ModelViews
{
    public class XemDonHang
    {
        public Order DonHang { get; set; }
        public List<ChitietOrder> ChiTietDonHang { get; set; }
    }
}
