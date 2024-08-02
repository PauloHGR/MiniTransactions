using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CustomerCase.Create
{
    public sealed class CreateCustomerMapper : Profile
    {
        public CreateCustomerMapper() {
            CreateMap<CreateCustomerRequest, Domain.Customers.Customer>();
            CreateMap<Domain.Customers.Customer, CreateCustomerResponse>();
        }
    }
}
