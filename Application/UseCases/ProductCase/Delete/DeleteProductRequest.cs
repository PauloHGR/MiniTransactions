using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.Delete
{
    public sealed record DeleteProductRequest(Guid Id) : IRequest<DeleteProductResponse>;
}
