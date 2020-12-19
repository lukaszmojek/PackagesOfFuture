using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Contracts;
using Api.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public AddressesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<AddressDto>>> GetAddresses()
        {
            var result = await _mediator.Send(new GetAddressesQuery());
            return result.Any() ? (ActionResult<ICollection<AddressDto>>) Ok(result) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addAddressDto)
        {
            var command = _mapper.Map<AddAddressCommand>(addAddressDto);
            var result = await _mediator.Send(command);
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
    }
}