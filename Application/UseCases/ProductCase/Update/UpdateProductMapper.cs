using Application.UseCases.Product.Create;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.Update
{
    public sealed class UpdateProductMapper : Profile
    {
        public UpdateProductMapper() {
            CreateMap<UpdateProductRequest, Domain.Products.Product>();
            CreateMap<Domain.Products.Product, UpdateProductResponse>();
        }
    }
}
