using MediatR;

namespace Application.UseCases.OrderCase.Create
{
    public sealed record CreateOrderRequest(
        string CPF,
        Guid ProductId,
        int Quantity) 
        : IRequest<CreateOrderResponse>;
}
