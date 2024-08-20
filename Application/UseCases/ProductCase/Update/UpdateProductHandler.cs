using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ProductCase.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductHandler(IProductRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException($"Product not found for Product Id{request.ProductId}");
            }

            product.Name = request.Name;
            product.Price = request.Price;

            _repository.Update(product);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return _mapper.Map<UpdateProductResponse>(product);
        }
    }
}
