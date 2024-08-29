using AutoMapper;

namespace Application.UseCases.OrderCase.Create
{
    public sealed class CreateOrderMapper : Profile
    {
        public CreateOrderMapper() {
            CreateMap<CreateOrderRequest, Domain.Orders.Order>();
            CreateMap<Domain.Orders.Order, CreateOrderResponse>()
                .ForMember(o => o.CustomerName, source => source.MapFrom(s => s.Customer.Name))
                .ForMember(o => o.ProductName, source => source.MapFrom(s => s.Product.Name));
        }
    }
}
