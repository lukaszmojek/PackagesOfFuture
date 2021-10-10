using System.Threading.Tasks;
using Contracts.Responses;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public LoginController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="logInDto">Representation of login details</param>
        /// <returns>User details</returns>
        /// <response code="200">When user was logged in</response>
        /// <response code="400">When no user with selected email and password exists</response>
        [HttpPost("")]
        public async Task<ActionResult<Response<LogInResponse>>> LogIn([FromBody] LogInDto logInDto)
        {
            var query = _mapper.Map<LogInQuery>(logInDto);
            var result = await _mediator.Send(query);
            
            return result.Succeeded ? (ActionResult<Response<LogInResponse>>) Ok(result) : BadRequest();
        }
    }
}