using AutoMapper;
using Domain.Interfaces;
using Domain.Products;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Application.UseCases.Product.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository productRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork) { 
            
            _repository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Domain.Products.Product product = _mapper.Map<Domain.Products.Product>(request);

            _repository.Add(product);

            await _unitOfWork.CompleteAsync(cancellationToken);
            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}
