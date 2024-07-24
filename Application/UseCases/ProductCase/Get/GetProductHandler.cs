using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.Get
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId, cancellationToken);

            if(product == null)
            {
                throw new NotFoundException($"Product not found for Product Id {request.ProductId}");
            }

            return _mapper.Map<GetProductResponse>(product);
        }
    }
}
