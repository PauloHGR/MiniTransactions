using MediatR;

namespace Application.UseCases.OrderCase.Delete
{
    public sealed record DeleteOrderRequest(string Id) : IRequest<DeleteOrderResponse>;
}
