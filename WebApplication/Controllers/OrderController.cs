using Application.UseCases.OrderCase.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniTransaction.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderResponse>> SaveOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(request, cancellationToken);
            return Created("Order", order);
        }
    }
}
