using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CustomerCase.Create
{
    public sealed record CreateCustomerRequest(string Name,
        string Email,
        string CPF,
        string Password) : IRequest<CreateCustomerResponse>;
}
