namespace EcommerceAPP.Data.Models
{
    public class UserPayment
    {
        public int ID { get; set; }
        public string CVV { get; set; } = null!;
        public string EXP { get; set; } = null!;
        public string DigitCode { get; set; } = null!;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
