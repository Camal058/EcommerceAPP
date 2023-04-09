using System;
using System.Collections.Generic;

namespace EcommerceAPP.Data.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
    }
}
