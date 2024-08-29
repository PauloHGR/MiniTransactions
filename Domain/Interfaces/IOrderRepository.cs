using Domain.Orders;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
