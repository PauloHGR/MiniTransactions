using Application.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed record GetAllProductRequest(string Name, 
        int Quantity, 
        double Price,
        int Size,
        int Offset,
        ProductSortField ProductSortField, 
        SortOrder SortOrder) : IRequest<List<GetAllProductResponse>>
    {
    }
}
