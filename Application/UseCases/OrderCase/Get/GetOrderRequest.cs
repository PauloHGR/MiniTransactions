using MediatR;

namespace Application.UseCases.OrderCase.Get
{
    public sealed record GetOrderRequest(string CPF, string ProductId) : IRequest<List<GetOrderResponse>>;
}
