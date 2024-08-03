using MediatR;

namespace Application.UseCases.CustomerCase.Delete
{
    public sealed record DeleteCustomerRequest(Guid CustomerId) : IRequest<DeleteCustomerResponse>;
}
