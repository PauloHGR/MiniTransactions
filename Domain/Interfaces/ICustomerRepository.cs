using Domain.Customers;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Remove(Customer customer);
        Task<Customer> GetCustomerByIdAsync(Guid CustomerId, CancellationToken cancellationToken);
        Task<Customer> GetCustomerByCPFAsync(string CPF, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken);
        IEnumerable<Customer> GetCustomersByFilters(Func<Customer, bool> predicate);
    }
}
