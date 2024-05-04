using MediatR;

namespace Application.UseCases.Product.Create
{
    public sealed record CreateProductRequest(string Name, string Price) : IRequest<CreateProductResponse>;
}
