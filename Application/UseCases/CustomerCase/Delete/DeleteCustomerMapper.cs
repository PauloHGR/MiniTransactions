using AutoMapper;

namespace Application.UseCases.CustomerCase.Delete
{
    public sealed class DeleteCustomerMapper : Profile
    {
        public DeleteCustomerMapper() {
            CreateMap<DeleteCustomerRequest, Domain.Customers.Customer>();
            CreateMap<Domain.Customers.Customer, DeleteCustomerResponse>();
        }
    }
}
