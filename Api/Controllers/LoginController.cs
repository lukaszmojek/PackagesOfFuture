using System.Threading.Tasks;
using Api.Contracts;
using Api.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Responses;

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
        
        [HttpPost("")]
        public async Task<ActionResult<Response<LogInResponse>>> LogIn([FromBody] LogInDto logInDto)
        {
            var query = _mapper.Map<LogInQuery>(logInDto);
            var result = await _mediator.Send(query);
            return result.Succeeded ? (ActionResult<Response<LogInResponse>>) Ok(result) : NotFound();
        }
    }
}