using System.Threading.Tasks;
using Contracts.Responses;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="authenticateUserDto">Representation of login details</param>
        /// <returns>User details</returns>
        /// <response code="200">When user was logged in</response>
        /// <response code="400">When no user with selected email and password exists</response>
        [HttpPost("")]
        public async Task<ActionResult<Response<AuthenticateUserResponse>>> Authenticate([FromBody] AuthenticateUserDto authenticateUserDto)
        {
            var query = _mapper.Map<AuthenticateUserQuery>(authenticateUserDto);
            var result = await _mediator.Send(query);
            
            return result.Succeeded ? Ok(result) : BadRequest(result.Error);
        }
    }
}