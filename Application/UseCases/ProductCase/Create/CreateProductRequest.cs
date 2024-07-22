using MediatR;

namespace Application.UseCases.Product.Create
{
    public sealed record CreateProductRequest(string Name, int Quantity, double Price) : IRequest<CreateProductResponse>;
}
