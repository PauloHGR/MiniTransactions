using AutoMapper;

namespace Application.UseCases.OrderCase.Delete
{
    public class DeleteOrderMapper : Profile
    {
        public DeleteOrderMapper() {
            CreateMap<Domain.Orders.Order, DeleteOrderResponse>();
        }
    }
}
