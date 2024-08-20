using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CustomerCase.Update
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByCPFAsync(request.CPF, cancellationToken);

            if (customer == null)
            {
                throw new NotFoundException($"Customer not found for CPF {request.CPF}");
            }

            customer.Name = string.IsNullOrEmpty(request.Name) ? customer.Name : request.Name;
            customer.Email = string.IsNullOrEmpty(request.Email) ? customer.Email : request.Email;

            _customerRepository.Update(customer);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<UpdateCustomerResponse>(customer);
        }
    }
}
