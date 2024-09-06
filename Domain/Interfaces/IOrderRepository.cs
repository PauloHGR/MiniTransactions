using Domain.Orders;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken, Expression<Func<Order, bool>>? filter = null);
        Task<Order?> GetOrderByIdAsync(string id, CancellationToken cancellationToken);
        void Update(Order order);
        void Remove(Order order);
    }
}
