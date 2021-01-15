using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
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
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<SupportIssueDto>>> GetServiceIssues()
        {
            var results = await _mediator.Send(new GetSupportIssuesQuery());
            
            return results.Any() ? (ActionResult<ICollection<SupportIssueDto>>) Ok(results) : NotFound();
        }
        
        [HttpGet("user-issues/{userId}")]
        public async Task<ActionResult<ICollection<SupportIssueDto>>> GetUserIssues([FromRoute] int userId)
        {
            var results = await _mediator.Send(new GetUserSupportIssuesQuery(){ UserId = userId});
            
            return results.Any() ? (ActionResult<ICollection<SupportIssueDto>>) Ok(results) : NotFound();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterServiceIssue([FromBody] RegisterSupportIssueDto registerServiceIssueDto)
        {
            var command = _mapper.Map<RegisterSupportIssueCommand>(registerServiceIssueDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) NoContent() : BadRequest();
        }
    }
}