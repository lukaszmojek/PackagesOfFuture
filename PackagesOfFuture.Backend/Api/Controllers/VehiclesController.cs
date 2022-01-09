using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Auth;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VehiclesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all vehicles
    /// </summary>
    /// <returns>All vehicles from database</returns>
    /// <response code="200">When there are vehicles</response>
    /// <response code="404">If there are no vehicles</response>
    [HttpGet("")]
    public async Task<ActionResult<ICollection<VehicleDto>>> GetVehicles()
    {
        var results = await _mediator.Send(new GetVehiclesQuery());

        return results.Any() ? (ActionResult<ICollection<VehicleDto>>) Ok(results) : NotFound();
    }

    /// <summary>
    /// Registers a new vehicle
    /// </summary>
    /// <param name="registerVehicleDto">Representation of vehicle to register</param>
    /// <returns>Nothing. Query GetVehicles for current database status</returns>
    /// <response code="204">When vehicle was registered</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("")]
    public async Task<IActionResult> RegisterVehicle([FromBody] RegisterVehicleDto registerVehicleDto)
    {
        var command = _mapper.Map<RegisterVehicleCommand>(registerVehicleDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
    }
}