using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.OrderCase.Delete
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderHandler(IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.Id, cancellationToken);
            
            if (order == null)
            {
                throw new NotFoundException($"Order not found for Id {request.Id}");
            }

            _orderRepository.Remove(order);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<DeleteOrderResponse>(order);
        }
    }
}
