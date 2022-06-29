﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
            ChitietOrders = new HashSet<ChitietOrder>();
        }

        public int Id { get; set; }
        public string ProducName { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string Thumb { get; set; }
        public string Video { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool BestSeller { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public int? UnitslnStock { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
        public virtual ICollection<ChitietOrder> ChitietOrders { get; set; }
    }
}
