using AutoMapper;

namespace Application.UseCases.Product.Create
{
    public sealed class CreateProductMapper : Profile
    {
        public CreateProductMapper() {
            CreateMap<CreateProductRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, CreateProductResponse>();
        }
    }
}
