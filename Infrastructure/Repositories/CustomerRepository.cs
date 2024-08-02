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
        public void Add(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
        }
    }
}
