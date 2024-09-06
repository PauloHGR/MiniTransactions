using MediatR;

namespace Application.UseCases.OrderCase.GetById
{
    public sealed record GetOrderByIdRequest(string Id) : IRequest<GetOrderByIdResponse>;
}
