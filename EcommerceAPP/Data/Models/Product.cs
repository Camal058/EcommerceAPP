using System;
using System.Collections.Generic;


namespace EcommerceAPP.Data.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;


        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
