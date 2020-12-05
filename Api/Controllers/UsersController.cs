using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Commands;
using WebApplication.Profiles;
using WebApplication.Queries;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var command = _mapper.Map<Commands.RegisterUser>(registerUserDto);
            var result = await _mediator.Send(command);
            return result.Succeded ? (IActionResult) Ok() : BadRequest();
        }
    }
}