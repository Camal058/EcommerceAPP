namespace EcommerceAPP.Data.Models
{
    public class OrderProduct
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
