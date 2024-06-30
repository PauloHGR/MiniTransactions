using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll(cancellationToken);

            return _mapper.Map<List<GetAllProductResponse>>(products);
        }
    }
}
