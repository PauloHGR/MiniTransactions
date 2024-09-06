using AutoMapper;

namespace Application.UseCases.OrderCase.GetById
{
    public class GetOrderByIdMapper : Profile
    {
        public GetOrderByIdMapper() {
            CreateMap<GetOrderByIdRequest, Domain.Orders.Order>();
            CreateMap<Domain.Orders.Order, GetOrderByIdResponse>();
        }
    }
}
