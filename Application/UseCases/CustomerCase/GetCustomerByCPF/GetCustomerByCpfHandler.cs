
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CustomerCase.GetCustomerByCPF
{
    public class GetCustomerByCpfHandler : IRequestHandler<GetCustomerByCPFRequest, GetCustomerByCpfResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByCpfHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<GetCustomerByCpfResponse> Handle(GetCustomerByCPFRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByCPFAsync(request.CPF, cancellationToken);

            if(customer == null)
            {
                throw new NotFoundException($"Customer not found for CPF {request.CPF}");
            }

            return _mapper.Map<GetCustomerByCpfResponse>(customer);
        }
    }
}
