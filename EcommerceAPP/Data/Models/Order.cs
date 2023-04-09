using System;
using System.Collections.Generic;


namespace EcommerceAPP.Data.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
