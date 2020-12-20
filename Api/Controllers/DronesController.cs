using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Contracts;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public DronesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<DroneDto>>> GetDrones()
        {
            var result = await _mediator.Send(new GetDronesQuery());
            return result.Any() ? (ActionResult<ICollection<DroneDto>>) Ok(result) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterDrone([FromBody] RegisterDroneDto registerDroneDto)
        {
            var command = _mapper.Map<RegisterDroneCommand>(registerDroneDto);
            var result = await _mediator.Send(command);
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
        
        [HttpPost("{droneId}/moveToSorting")]
        public async Task<IActionResult> MoveDroneToSorting(
            [FromRoute] int droneId,
            [FromBody] MoveDroneToSortingDto moveDroneDroneToSortingDto)
        {
            var command = _mapper.Map<MoveDroneToSortingCommand>(moveDroneDroneToSortingDto);
            var result = await _mediator.Send(command);
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
        }
    }
}