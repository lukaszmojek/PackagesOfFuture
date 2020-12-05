using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Commands;
using WebApplication.Queries;

namespace WebApplication.Controllers
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
            var result = await _mediator.Send(new Seed());
            return result.Succeded ? (IActionResult) Ok() : BadRequest();
        }
    }
}