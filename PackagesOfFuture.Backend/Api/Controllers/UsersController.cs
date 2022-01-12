using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Auth;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
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

    /// <summary>
    /// Gets all users
    /// </summary>
    /// <returns>All users from database</returns>
    /// <response code="200">When there are users</response>
    /// <response code="404">If there are no users</response>
    [HttpGet("")]
    public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
    {
        var command = new GetUsersQuery();
        var result = await _mediator.Send(command);

        return result.Any() ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <returns>User by id from database</returns>
    /// <response code="200">When there is user</response>
    /// <response code="404">If there isnt user</response>
    [HttpGet("getByUserId/{userId}")]
    public async Task<ActionResult<ICollection<UserDto>>> GetUserById(int userId)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(userId));
        return result != null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="registerUserDto">Representation of user to register</param>
    /// <returns>Nothing. Query GetUsers for current database status</returns>
    /// <response code="204">When user was registered</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
    {
        var command = _mapper.Map<RegisterUserCommand>(registerUserDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? NoContent() : BadRequest(result.Error);
    }

    /// <summary>
    /// Changes user details
    /// </summary>
    /// <param name="id">Id of a user</param>
    /// <param name="changeUserDetailsDto">Representation of user details to change</param>
    /// <returns>Nothing. Query GetUsers for current database status</returns>
    /// <response code="204">When user details was changed</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("{id}/change-details")]
    public async Task<IActionResult> ChangeUserDetails(
        [FromRoute] int id,
        [FromBody] ChangeUserDetailsDto changeUserDetailsDto
    )
    {
        var command = _mapper.Map<ChangeUserDetailsCommand>(changeUserDetailsDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? NoContent() : NotFound();
    }

    /// <summary>
    /// Changes user password
    /// </summary>
    /// <param name="id">Id of a user</param>
    /// <param name="changeUserPasswordDto">Representation of user password to change</param>
    /// <returns>Nothing. Query GetUsers for current database status</returns>
    /// <response code="204">When user password was changed</response>
    /// <response code="400">When error regarding input occurred</response>
    [HttpPost("{id}/change-password")]
    public async Task<IActionResult> ChangeUserPassword(
        [FromRoute] int id,
        [FromBody] ChangeUserPasswordDto changeUserPasswordDto
    )
    {
        var command = _mapper.Map<ChangeUserPasswordCommand>(changeUserPasswordDto);
        var result = await _mediator.Send(command);

        return result.Succeeded ? NoContent() : NotFound();
    }

    /// <summary>
    /// Changes user details
    /// </summary>
    /// <param name="id">Id of a user</param>
    /// <returns>Nothing. Query GetUsers for current database status</returns>
    /// <response code="204">When user was unregistered</response>
    /// <response code="404">When no user with selected id exists</response>
    [HttpDelete("{id}/unregister")]
    public async Task<IActionResult> UnregisterUser(
        [FromRoute] int id
    )
    {
        var result = await _mediator.Send(new UnregisterUserCommand() {UserId = id});

        return result.Succeeded ? NoContent() : NotFound();
    }
}