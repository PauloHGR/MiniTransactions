using MediatR;

namespace Application.UseCases.CustomerCase.GetCustomerByCPF
{
    public sealed record GetCustomerByCPFRequest(string CPF) : IRequest<GetCustomerByCpfResponse>;
}
