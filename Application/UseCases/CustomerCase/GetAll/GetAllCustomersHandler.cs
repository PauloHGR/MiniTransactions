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

        private static bool IsRequestFilterValid(GetAllCustomersRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name) ||
                !string.IsNullOrEmpty(request.CPF) ||
                !string.IsNullOrEmpty(request.Email))
                return true;

            return false;
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

            if(IsRequestFilterValid(request))
            {
                var customers_filtered = await _customerRepository.GetCustomersAsync(cancellationToken, p => p.Name == request.Name ||
                p.CPF == request.CPF ||
                p.Email == request.Email);

                customers_filtered = request.SortOrder == Enums.SortOrder.ASC ? customers_filtered.OrderBy(func) : customers_filtered.OrderByDescending(func);
                customers_filtered = customers_filtered.Skip(request.Offset).Take(request.Size);

                return _mapper.Map<List<GetAllCustomersResponse>>(customers_filtered);
            }

            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);
            customers = request.SortOrder == Enums.SortOrder.ASC ? customers.OrderBy(func) : customers.OrderByDescending(func);
            customers = customers.Skip(request.Offset).Take(request.Size).ToList();

            return _mapper.Map<List<GetAllCustomersResponse>>(customers);
        }
    }
}
