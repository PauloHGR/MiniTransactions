using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.Get
{
    public sealed record GetProductRequest(Guid ProductId) : IRequest<GetProductResponse>;
}
