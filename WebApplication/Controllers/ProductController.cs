using Application.UseCases.Product.Create;
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
    }
}
