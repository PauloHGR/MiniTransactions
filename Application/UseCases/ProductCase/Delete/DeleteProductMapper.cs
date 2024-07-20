using AutoMapper;

namespace Application.UseCases.ProductCase.Delete
{
    public sealed class DeleteProductMapper : Profile
    {
        public DeleteProductMapper() {
            CreateMap<DeleteProductRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, DeleteProductResponse>();
        }
    }
}
