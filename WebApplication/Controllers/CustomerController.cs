using Application.UseCases.CustomerCase.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MiniTransaction.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerResponse>> SaveCustomer(CreateCustomerRequest request, 
            CancellationToken cancellationToken)
        {
            CreateCustomerResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
