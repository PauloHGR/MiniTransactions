using Domain.Customers;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }
}
