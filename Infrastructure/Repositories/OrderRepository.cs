using Domain.Interfaces;
using Domain.Orders;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Order order)
        {
            _appDbContext.Orders.Add(order);
        }
    }
}
