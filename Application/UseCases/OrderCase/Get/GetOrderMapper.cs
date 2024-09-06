using AutoMapper;

namespace Application.UseCases.OrderCase.Get
{
    public sealed class GetOrderMapper : Profile
    {
        public GetOrderMapper() {
            CreateMap<GetOrderRequest, Domain.Orders.Order>();
            CreateMap<Domain.Orders.Order, GetOrderResponse>();
        }
    }
}
