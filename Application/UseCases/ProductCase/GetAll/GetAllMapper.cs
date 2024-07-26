using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed class GetAllMapper : Profile
    {
        public GetAllMapper() {
            CreateMap<GetAllProductRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, GetAllProductResponse>();
        }
    }
}
