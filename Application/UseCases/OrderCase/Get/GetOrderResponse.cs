using Domain.Orders;

namespace Application.UseCases.OrderCase.Get
{
    public sealed record GetOrderResponse(Guid Id,
        string CPF,
        Guid ProductId,
        double TotalValue,
        int Quantity,
        bool IsPayed);
}
