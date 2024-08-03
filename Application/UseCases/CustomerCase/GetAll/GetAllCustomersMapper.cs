using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CustomerCase.GetAll
{
    public class GetAllCustomersMapper : Profile
    {
        public GetAllCustomersMapper() {
            CreateMap<GetAllCustomersRequest, Domain.Customers.Customer>();
            CreateMap<Domain.Customers.Customer, GetAllCustomersResponse>();
        }
    }
}
