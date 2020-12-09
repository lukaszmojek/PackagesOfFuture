using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Contracts;
using WebApplication.Queries;
using WebApplication.Responses;

namespace WebApplication.Controllers
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
        public async Task<ActionResult<LogInResponse>> LogIn(LogInDto logInDto)
        {
            var query = _mapper.Map<LogInQuery>(logInDto);
            var result = await _mediator.Send(query);
            return result.Succeeded ? (ActionResult<LogInResponse>) Ok(result) : NotFound();
        }
    }
}