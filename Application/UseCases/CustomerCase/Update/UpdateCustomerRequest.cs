using MediatR;

namespace Application.UseCases.CustomerCase.Update
{
    public sealed record UpdateCustomerRequest(string CPF, string Name, string Email) : IRequest<UpdateCustomerResponse>;
}
