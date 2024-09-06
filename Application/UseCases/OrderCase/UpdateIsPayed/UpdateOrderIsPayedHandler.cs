using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.OrderCase.UpdateIsPayed
{
    public class UpdateOrderIsPayedHandler : IRequestHandler<UpdateOrderIsPayedRequest, UpdateOrderIsPayedResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderIsPayedHandler(IOrderRepository orderRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOrderIsPayedResponse> Handle(UpdateOrderIsPayedRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException($"Order not found for Id {request.Id}");
            }

            if (order.IsPayed)
            {
                throw new BadRequestException($"Order for Id {request.Id} already payed!");
            }

            order.IsPayed = true;
            _orderRepository.Update(order);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<UpdateOrderIsPayedResponse>(order);
        }
    }
}
