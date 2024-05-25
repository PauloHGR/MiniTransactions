using MediatR;

namespace Application.UseCases.Product.Create
{
    public sealed record CreateProductRequest(string Name, double Price) : IRequest<CreateProductResponse>;
}
