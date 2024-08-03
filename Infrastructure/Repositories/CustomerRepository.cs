using Domain.Customers;
using Domain.Interfaces;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid CustomerId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.Where(c => c.CustomerId == CustomerId).FirstAsync(cancellationToken);
        }

        public async Task<Customer> GetCustomerByCPFAsync(string CPF, CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.Where(c => c.CPF == CPF).FirstAsync(cancellationToken);
        }

        public void Remove(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.ToListAsync(cancellationToken);
        }

        public IEnumerable<Customer> GetCustomersByFilters(Func<Customer, bool> predicate)
        {
            var customer = _appDbContext.Customers;
            return customer.Where(predicate);
        }
    }
}
