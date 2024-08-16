using Domain.Customers;
using Domain.Interfaces;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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

        public async Task<Customer?> GetCustomerByCPFAsync(string CPF, CancellationToken cancellationToken)
        {
            var query = await _appDbContext.Customers.Where(c => c.CPF == CPF).FirstOrDefaultAsync(cancellationToken);
            return query;
        }

        public void Remove(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(CancellationToken cancellationToken, Expression<Func<Customer, bool>>? filter = null)
        {
            var customer = _appDbContext.Customers;
            return filter == null ? await customer.ToListAsync(cancellationToken) : await customer.Where(filter).ToListAsync(cancellationToken);
        }
    }
}
