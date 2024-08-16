using MediatR;

namespace Application.UseCases.CustomerCase.Delete
{
    public sealed record DeleteCustomerRequest(string CPF) : IRequest<DeleteCustomerResponse>;
}
