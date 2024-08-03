using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed class GetAllProductsMapper : Profile
    {
        public GetAllProductsMapper() {
            CreateMap<GetAllProductsRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, GetAllProductsResponse>();
        }
    }
}
