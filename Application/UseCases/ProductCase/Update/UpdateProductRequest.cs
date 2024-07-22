using MediatR;

namespace Application.UseCases.ProductCase.Update
{
    public sealed record UpdateProductRequest(Guid ProductId, string Name, int Quantity, double Price) : IRequest<UpdateProductResponse>;
}
