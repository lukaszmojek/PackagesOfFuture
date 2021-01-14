using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            var command = new GetUsersQuery();
            var result = await _mediator.Send(command);
            
            return result.Any() ? (ActionResult<ICollection<UserDto>>) Ok(result) : NotFound();
        }        
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var command = _mapper.Map<RegisterUserCommand>(registerUserDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
        
        [HttpPost("{id}/change-details")]
        public async Task<IActionResult> ChangeUserDetails(
            [FromRoute] int id,
            [FromBody] ChangeUserDetailsDto changeUserDetailsDto)
        {
            var command = _mapper.Map<ChangeUserDetailsCommand>(changeUserDetailsDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : NotFound();
        }
        
        [HttpPost("{id}/change-password")]
        public async Task<IActionResult> ChangeUserPassword(
            [FromRoute] int id,
            [FromBody] ChangeUserPasswordDto changeUserPasswordDto)
        {
            var command = _mapper.Map<ChangeUserPasswordCommand>(changeUserPasswordDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : NotFound();
        }
        
        [HttpDelete("{id}/unregister")]
        public async Task<IActionResult> UnregisterUser(
            [FromRoute] int id)
        {
            var result = await _mediator.Send(new UnregisterUserCommand(){ UserId = id });
            
            return result.Succeeded ? (IActionResult) NoContent() : NotFound();
        }
    }
}