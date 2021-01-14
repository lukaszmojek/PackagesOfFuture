using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Handlers;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public ServicesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<ServiceDto>>> GetServices()
        {
            var results = await _mediator.Send(new GetServicesQuery());
            
            return results.Any() ? (ActionResult<ICollection<ServiceDto>>) Ok(results) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterService([FromBody] RegisterServiceDto registerServiceDto)
        {
            var command = _mapper.Map<RegisterServiceCommand>(registerServiceDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
    }
}