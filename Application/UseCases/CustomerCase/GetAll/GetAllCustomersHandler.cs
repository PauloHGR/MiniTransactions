using Application.UseCases.ProductCase.GetAll;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CustomerCase.GetAll
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, List<GetAllCustomersResponse>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllCustomersResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            Func<Domain.Customers.Customer, object> func = request.CustomerSortField.ToString() switch
            {
                "Name" => customer => customer.Name,
                "Email" => customer => customer.Email,
                "CPF" => customer => customer.CPF,
                _ => customer => customer.Name
            };

            var customers = await _customerRepository.GetAllCustomersAsync(cancellationToken);
            customers = request.SortOrder == Enums.SortOrder.ASC ? customers.OrderBy(func) : customers.OrderByDescending(func);
            customers = customers.Skip(request.Offset).Take(request.Size).ToList();

            return _mapper.Map<List<GetAllCustomersResponse>>(customers);
        }
    }
}
