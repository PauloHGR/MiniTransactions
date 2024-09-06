using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.OrderCase.Get
{
    public class GetOrderHandler : IRequestHandler<GetOrderRequest, List<GetOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        private static bool IsValidFilterRequest(GetOrderRequest request)
        {
            if (!string.IsNullOrEmpty(request.CPF)
                || !string.IsNullOrEmpty(request.ProductId))
                return true;
            return false;
        }

        public async Task<List<GetOrderResponse>> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            if (IsValidFilterRequest(request))
            {
                var orders = await _orderRepository.GetOrdersAsync(cancellationToken, o => o.CPF == request.CPF || o.ProductId.ToString() == request.ProductId);
                return _mapper.Map<List<GetOrderResponse>>(orders);
            }
            var AllOrders = await _orderRepository.GetOrdersAsync(cancellationToken);
            AllOrders = AllOrders.Skip(request.Offset).Take(request.Size);
            return _mapper.Map<List<GetOrderResponse>>(AllOrders);

        }
    }
}
