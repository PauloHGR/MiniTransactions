using AutoMapper;

namespace Application.UseCases.CustomerCase.Update
{
    public sealed class UpdateCustomerMapper : Profile
    {
        public UpdateCustomerMapper() {
            CreateMap<UpdateCustomerRequest, Domain.Customers.Customer>();
            CreateMap<Domain.Customers.Customer, UpdateCustomerResponse>();
        }
    }
}
