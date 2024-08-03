using Application.Enums;
using MediatR;


namespace Application.UseCases.ProductCase.GetAll
{
    public sealed record GetAllProductsRequest(string Name, 
        int Quantity, 
        double Price,
        int Size,
        int Offset,
        ProductSortField ProductSortField, 
        SortOrder SortOrder) : IRequest<List<GetAllProductsResponse>>
    {
    }
}
