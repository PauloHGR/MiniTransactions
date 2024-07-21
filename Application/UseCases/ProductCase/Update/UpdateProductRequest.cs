using MediatR;

namespace Application.UseCases.ProductCase.Update
{
    public sealed record UpdateProductRequest(Guid Id, string Name, double Price) : IRequest<UpdateProductResponse>;
}
