using Domain.Orders;

namespace Domain.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
