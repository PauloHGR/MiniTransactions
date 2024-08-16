using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CustomerCase.Create
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Customers.Customer>(request);

            var queryByCPF = await _customerRepository.GetCustomerByCPFAsync(request.CPF, cancellationToken);

            if(queryByCPF != null)
            {
                throw new BadRequestException($"Customer already exists for CPF {request.CPF}");
            }

            _customerRepository.Add(customer);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<CreateCustomerResponse>(customer);
        }
    }
}
