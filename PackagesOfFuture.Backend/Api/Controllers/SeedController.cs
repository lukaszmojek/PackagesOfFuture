using System.Threading.Tasks;
using Api.Auth;
using Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[IsAdmin]
[Route("[controller]")]
public class SeedController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Seeds a database with predefined data
    /// </summary>
    /// <returns>Nothing</returns>
    /// <response code="204">When data was seeded</response>
    /// <response code="400">When error occurred</response>
    [HttpPost("")]
    public async Task<IActionResult> Seed()
    {
        var result = await _mediator.Send(new SeedCommand());
        return result.Succeeded ? Ok() : BadRequest(result.Error);
    }
}