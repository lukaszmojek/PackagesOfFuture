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
public class SortingsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SortingsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all sortings
    /// </summary>
    /// <returns>All sortings from database</returns>
    /// <response code="200">When there are sortings</response>
    /// <response code="404">If there are no sortings</response>
    [HttpGet("")]
    public async Task<ActionResult<ICollection<SortingDto>>> GetSortings()
    {
        var results = await _mediator.Send(new GetSortingsQuery());

        return results.Any() ? (ActionResult<ICollection<SortingDto>>) Ok(results) : NotFound();
    }

    /// <summary>
    /// Registers a new sorting
    /// </summary>
    /// <param name="registerSortingDto">Representation of sorting to register</param>
    /// <returns>Nothing. Query GetSortings for current database status</returns>
    /// <response code="204">When service was registered</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("")]
    public async Task<IActionResult> RegisterSorting([FromBody] RegisterSortingDto registerSortingDto)
    {
        var command = _mapper.Map<RegisterSortingCommand>(registerSortingDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
    }

    /// <summary>
    /// Changes sorting details
    /// </summary>
    /// <param name="changeSortingDetailsDto">Details of sorting to change</param>
    /// <returns>Nothing. Query GetSortings for current database status</returns>
    /// <response code="204">When sorting was changed</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("{sortingId}/change-details")]
    public async Task<IActionResult> ChangeSortingDetails(
        [FromRoute] int sortingId,
        [FromBody] ChangeSortingDetailsDto changeSortingDetailsDto
    )
    {
        var command = _mapper.Map<ChangeSortingDetailsCommand>(changeSortingDetailsDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
    }
}