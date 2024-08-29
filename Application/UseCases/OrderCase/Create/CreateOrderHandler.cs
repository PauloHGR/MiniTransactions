using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Orders;
using MediatR;

namespace Application.UseCases.OrderCase.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrderRepository orderRepository,
            ICustomerRepository customerRepository, 
            IProductRepository productRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private static bool IsQuantityInRange(int quantitySent, int quantityRemains)
        {
            return quantitySent <= quantityRemains ? true : false;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByCPFAsync(request.CPF, cancellationToken) ?? throw new NotFoundException($"Customer not found for CPF {request.CPF}");
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken) ?? throw new NotFoundException($"Product not found for Product Id {request.ProductId}");

            if (!IsQuantityInRange(request.Quantity, product.Quantity))
            {
                throw new BadRequestException($"The quantity of {product.Name} available is just {product.Quantity}, please enter with less!");
            }

            var order = new Order()
            {
                CPF = customer.CPF,
                ProductId = product.ProductId,
                Quantity = request.Quantity,
                TotalValue = product.Price * request.Quantity,
                IsPayed = false
            };

            _orderRepository.Add(order);

            product.Quantity -= request.Quantity;
            _productRepository.Update(product);

            await _unitOfWork.CompleteAsync(cancellationToken);
            return _mapper.Map<CreateOrderResponse>(order);
        }
    }
}
