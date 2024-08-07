﻿using Application.UseCases.CustomerCase.Create;
using Application.UseCases.CustomerCase.Delete;
using Application.UseCases.CustomerCase.GetAll;
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
        public async Task<ActionResult<CreateCustomerResponse>> SaveCustomerAsync(CreateCustomerRequest request, 
            CancellationToken cancellationToken)
        {
            CreateCustomerResponse response = await _mediator.Send(request, cancellationToken);
            return Created("Customer", response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllCustomersResponse>>> GetAllCustomersAsync([FromQuery]GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            List<GetAllCustomersResponse> response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerResponse>> DeleteCustomerAsync(Guid id, CancellationToken cancellationToken)
        {
            DeleteCustomerRequest request = new(id);
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }
    }
}
