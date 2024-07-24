using AutoMapper;

namespace Application.UseCases.ProductCase.Get
{
    public sealed class GetProductMapper : Profile
    {
        public GetProductMapper() {
            CreateMap<GetProductRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, GetProductResponse>();
        }
    }
}
