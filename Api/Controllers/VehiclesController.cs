using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
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
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<VehicleDto>>> GetVehicles()
        {
            var results = await _mediator.Send(new GetVehiclesQuery());
            
            return results.Any() ? (ActionResult<ICollection<VehicleDto>>) Ok(results) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterVehicle([FromBody] RegisterVehicleDto registerVehicleDto)
        {
            var command = _mapper.Map<RegisterVehicleCommand>(registerVehicleDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
    }
}