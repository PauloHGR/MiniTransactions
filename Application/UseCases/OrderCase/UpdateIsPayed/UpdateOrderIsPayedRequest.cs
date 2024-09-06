using MediatR;

namespace Application.UseCases.OrderCase.UpdateIsPayed
{
    public sealed record UpdateOrderIsPayedRequest(string Id) : IRequest<UpdateOrderIsPayedResponse>;
}
