using Domain.Customers;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _appDbContext.Customers.AddAsync(customer, cancellationToken);
        }
    }
}
