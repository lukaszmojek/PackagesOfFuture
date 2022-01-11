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
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public AddressesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all addresses
    /// </summary>
    /// <returns>All addresses in database</returns>
    /// <response code="200">When addresses exist</response>
    /// <response code="404">When error regarding input occurred</response>
    [HttpGet("")]
    public async Task<ActionResult<ICollection<AddressDto>>> GetAddresses()
    {
        var result = await _mediator.Send(new GetAddressesQuery());
        return result.Any() ? Ok(result) : NotFound();
    }
    
    /// <summary>
    /// Get address of the userId
    /// </summary>
    /// <returns>Address of the user</returns>
    /// <response code="200">When user with given id exist</response>
    /// <response code="404">When error regarding input occurred</response>
    [HttpGet("getByUserId/{userId}")]
    public async Task<ActionResult<AddressDto>> GetAddressesByUserId(int userId)
    {
        var result = await _mediator.Send(new GetAddressByUserIdQuery(userId));
        return result != null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Registers a new package
    /// </summary>
    /// <param name="addAddressDto">Representation of address to add</param>
    /// <returns>Nothing. Query GetAddresses to </returns>
    /// <response code="204">When package was registered</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("")]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addAddressDto)
    {
        var command = _mapper.Map<AddAddressCommand>(addAddressDto);
        var result = await _mediator.Send(command);
        return result.Succeeded ? NoContent() : BadRequest();
    }
}