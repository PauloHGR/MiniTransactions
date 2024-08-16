using AutoMapper;

namespace Application.UseCases.CustomerCase.GetCustomerByCPF
{
    public sealed class GetCustomerByCpfMapper : Profile
    {
        public GetCustomerByCpfMapper()
        {
            CreateMap<Domain.Customers.Customer, GetCustomerByCpfResponse>();
        }
    }
}
