using AutoMapper;

namespace Application.UseCases.ProductCase.Get
{
    public sealed class GetProductByIdMapper : Profile
    {
        public GetProductByIdMapper() {
            CreateMap<GetProductByIdRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, GetProductByIdResponse>();
        }
    }
}
