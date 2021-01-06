using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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