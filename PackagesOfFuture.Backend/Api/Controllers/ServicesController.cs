using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Handlers;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
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
        
        /// <summary>
        /// Gets all services
        /// </summary>
        /// <returns>All services from database</returns>
        /// <response code="200">When there are services</response>
        /// <response code="404">If there are no services</response>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<ServiceDto>>> GetServices()
        {
            var results = await _mediator.Send(new GetServicesQuery());
            
            return results.Any() ? (ActionResult<ICollection<ServiceDto>>) Ok(results) : NotFound();
        }
        
        /// <summary>
        /// Registers a new service
        /// </summary>
        /// <param name="registerServiceDto">Representation of service to register</param>
        /// <returns>Nothing. Query GetServices for current database status</returns>
        /// <response code="204">When service was registered</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("")]
        public async Task<IActionResult> RegisterService([FromBody] RegisterServiceDto registerServiceDto)
        {
            var command = _mapper.Map<RegisterServiceCommand>(registerServiceDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest(result.Error);
        }
    }
}