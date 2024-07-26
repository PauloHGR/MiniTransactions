using AutoMapper;
using Domain.Interfaces;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(IProductRepository repository, IMapper mapper) { 
            _repository = repository;
            _mapper = mapper;
        }

        private bool IsRequestFilterValid(GetAllProductRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name) ||
                request.Price != 0 ||
                request.Quantity != 0)
                return true;

            return false;
        }
        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            Func<Domain.Products.Product, object> func = request.ProductSortField.ToString() switch
            {
                "Name" => product => product.Name,
                "Price" => product => product.Price,
                "Quantity" => product => product.Quantity,
                _ => product => product.Name
            };

            if (IsRequestFilterValid(request))
            {
                var products_filtered = _repository.GetProductsFiltered(p => p.Name == request.Name || 
                p.Quantity == request.Quantity || 
                p.Price == request.Price);

                products_filtered = request.SortOrder == Enums.SortOrder.ASC ? products_filtered.OrderBy(a => a.Name) : products_filtered.OrderByDescending(func);
                products_filtered = products_filtered.Skip(request.Offset).Take(request.Size);

                return _mapper.Map<List<GetAllProductResponse>>(products_filtered);
            }

            var products = await _repository.GetAll(cancellationToken);
            products = request.SortOrder == Enums.SortOrder.ASC ? products.OrderBy(func) : products.OrderByDescending(func);
            products = products.Skip(request.Offset).Take(request.Size).ToList();

            return _mapper.Map<List<GetAllProductResponse>>(products);
        }
    }
}
