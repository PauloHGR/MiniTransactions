using AutoMapper;

namespace Application.UseCases.OrderCase.UpdateIsPayed
{
    public class UpdateOrderIsPayedMapper : Profile
    {
        public UpdateOrderIsPayedMapper()
        {
            CreateMap<Domain.Orders.Order, UpdateOrderIsPayedResponse>();
        }
    }
}
