using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Auth;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;

namespace Api.Controllers;

[Authorize]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PaymentsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all payments
    /// </summary>
    /// <returns>All payments from database</returns>
    /// <response code="200">When there are payments</response>
    /// <response code="404">If there are no payments</response>
    [HttpGet("")]
    public async Task<ActionResult<ICollection<PaymentDto>>> GetPayments()
    {
        var result = await _mediator.Send(new GetPaymentsQuery());
        return result.Any() ? (ActionResult<ICollection<PaymentDto>>) Ok(result) : NotFound();
    }

    /// <summary>
    /// Changes status of a payment
    /// </summary>
    /// <param name="changePaymentStatus">Details of payment status change</param>
    /// <returns>Nothing. Query GetPayments for current database status</returns>
    /// <response code="204">When payment status was changed</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("change-status")]
    public async Task<IActionResult> ChangePaymentStatus([FromBody] ChangePaymentStatusDto changePaymentStatus)
    {
        var command = _mapper.Map<ChangePaymentStatusCommand>(changePaymentStatus);
        var result = await _mediator.Send(command);

        return result.Succeeded ? (IActionResult) NoContent() : NotFound();
    }
}