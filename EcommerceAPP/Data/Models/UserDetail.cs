﻿namespace EcommerceAPP.Data.Models
{
    public class UserDetail
    {
        public int ID { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
