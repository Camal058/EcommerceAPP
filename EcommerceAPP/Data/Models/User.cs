using System;
using System.Collections.Generic;
using EcommerceAPP.Services.Interfaces;


namespace EcommerceAPP.Data.Models
{
    public class User : ISendable
    {
        public int ID { get; set; }
        public string Login { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public bool IsAdmin { get; set; }


        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; } = null!;


        public ICollection<Order>? Orders { get; set; }
        public ICollection<UserPayment>? UserPayments { get; set; }
    }
}
