using Application.UseCases.Product.Create;
using Application.UseCases.ProductCase.Delete;
using Application.UseCases.ProductCase.GetAll;
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
        public async Task<ActionResult<GetAllProductResponse>> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteProductResponse>> DeleteProduct([FromQuery]DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}
