using Domain.Customers;
using Domain.Products;

namespace Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? CPF { get; set; }
        public Guid ProductId { get; set; }
        public double TotalValue { get; set; }
        public int Quantity { get; set; }
        public bool IsPayed { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
