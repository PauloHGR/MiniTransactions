using Domain.Customers;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Remove(Customer customer);
        Task<Customer?> GetCustomerByCPFAsync(string CPF, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetCustomersAsync(CancellationToken cancellationToken, Expression<Func<Customer, bool>>? filter = null);
    }
}
