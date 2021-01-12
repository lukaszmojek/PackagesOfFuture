using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<ICollection<PaymentDto>>> GetPayments()
        {
            var result = await _mediator.Send(new GetPaymentsQuery());
            return result.Any() ? (ActionResult<ICollection<PaymentDto>>)Ok(result) : NotFound();
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangePaymentStatus([FromBody] ChangePaymentStatusDto changePaymentStatus)
        {
            var command = _mapper.Map<ChangePaymentStatusCommand>(changePaymentStatus);
            var result = await _mediator.Send(command);

            return result.Succeeded ? (IActionResult)Ok() : NotFound();
        }
    }
}
