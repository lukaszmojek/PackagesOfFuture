using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Queries;

namespace WebApplication.Controllers
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
            var result = await _mediator.Send(new GetAddresses());
            return result != null ? (ActionResult<ICollection<AddressDto>>) Ok(result) : NotFound();
        }
    }
}