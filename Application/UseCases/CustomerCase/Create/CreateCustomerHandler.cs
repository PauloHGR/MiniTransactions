using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _customerRepository.Add(customer);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<CreateCustomerResponse>(customer);
        }
    }
}
