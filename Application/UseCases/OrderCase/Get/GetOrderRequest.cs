using MediatR;

namespace Application.UseCases.OrderCase.Get
{
    public sealed record GetOrderRequest(string CPF, 
        string ProductId,
        int Offset = 0,
        int Size = 20) : IRequest<List<GetOrderResponse>>;
}
