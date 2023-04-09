using EcommerceAPP.Data.Models;

namespace EcommerceAPP.Message
{
    public class UsersMessage
    {
        public User? SentUser { get; set; } = new();
    }
}
