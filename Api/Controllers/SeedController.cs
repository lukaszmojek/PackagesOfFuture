using System.Threading.Tasks;
using Api.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public SeedController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Seed()
        {
            var result = await _mediator.Send(new SeedCommand());
            return result.Succeeded ? (IActionResult) Ok() : BadRequest();
        }
    }
}