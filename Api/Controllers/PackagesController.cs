using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Contracts;
using WebApplication.Queries;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public PackagesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<ICollection<PackageDto>>> GetPackages()
        {
            var result = await _mediator.Send(new GetPackagesQuery());
            return result.Any() ? (ActionResult<ICollection<PackageDto>>) Ok(result) : NotFound();
        }
    }
}