using Application.Enums;
using Application.UseCases.Product.Create;
using Application.UseCases.ProductCase.Delete;
using Application.UseCases.ProductCase.Get;
using Application.UseCases.ProductCase.GetAll;
using Application.UseCases.ProductCase.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> SaveProduct(CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            CreateProductResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllProductsResponse>> GetProducts(
            string Name,
            double Price,
            int Quantity,
            int Size,
            int Offset,
            ProductSortField sortField,
            SortOrder order,
            CancellationToken cancellationToken)
        {
            GetAllProductsRequest request = new(Name, Quantity, Price, Size, Offset, sortField, order);
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<GetProductByIdResponse>> GetProductById(Guid id, CancellationToken cancellationToken)
        {
            GetProductByIdRequest request = new(id);
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductResponse>> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {

            DeleteProductRequest request = new(id);
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}
