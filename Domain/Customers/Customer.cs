
using Domain.Orders;

namespace Domain.Customers
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
