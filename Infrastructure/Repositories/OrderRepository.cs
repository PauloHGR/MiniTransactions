using Domain.Interfaces;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken, Expression<Func<Order, bool>>? filter = null)
        {
            var order = _appDbContext.Orders;
            return filter == null ? await order.ToListAsync(cancellationToken) : await order.Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<Order?> GetOrderByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id.ToString() == id, cancellationToken);
        }

        public void Update(Order order)
        {
            _appDbContext.Update(order);
        }

        public void Remove(Order order)
        {
            _appDbContext.Orders.Remove(order);
        }
    }
}
