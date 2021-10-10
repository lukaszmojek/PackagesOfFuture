using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("support-issues")]
    public class SupportIssuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public SupportIssuesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Gets all support issues
        /// </summary>
        /// <returns>All support issues from database</returns>
        /// <response code="200">When there are support issues</response>
        /// <response code="404">If there are no support issues</response>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<SupportIssueDto>>> GetSupportIssues()
        {
            var results = await _mediator.Send(new GetSupportIssuesQuery());
            
            return results.Any() ? (ActionResult<ICollection<SupportIssueDto>>) Ok(results) : NotFound();
        }
        
        /// <summary>
        /// Gets support issues for user
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>User support issues from database</returns>
        /// <response code="200">When there are support issues</response>
        /// <response code="404">If there are no support issues</response>
        [HttpGet("user-issues/{userId}")]
        public async Task<ActionResult<ICollection<SupportIssueDto>>> GetUserIssues([FromRoute] int userId)
        {
            var results = await _mediator.Send(new GetUserSupportIssuesQuery(){ UserId = userId});
            
            return results.Any() ? (ActionResult<ICollection<SupportIssueDto>>) Ok(results) : NotFound();
        }
        
        /// <summary>
        /// Registers a new support issue
        /// </summary>
        /// <param name="registerServiceIssueDto">Representation of support issue to register</param>
        /// <returns>Nothing. Query GetSupportIssues for current database status</returns>
        /// <response code="204">When support issue was registered</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("")]
        public async Task<IActionResult> RegisterServiceIssue([FromBody] RegisterSupportIssueDto registerServiceIssueDto)
        {
            var command = _mapper.Map<RegisterSupportIssueCommand>(registerServiceIssueDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
        
        /// <summary>
        /// Changes status of a support issue
        /// </summary>
        /// <param name="changeSupportIssueStatusDto">Details of support issue status change</param>
        /// <returns>Nothing. Query GetSupportIssues for current database status</returns>
        /// <response code="204">When support issue was changed</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeServiceIssueStatus([FromBody] ChangeSupportIssueStatusDto changeSupportIssueStatusDto)
        {
            var command = _mapper.Map<ChangeSupportIssueStatusCommand>(changeSupportIssueStatusDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
    }
}