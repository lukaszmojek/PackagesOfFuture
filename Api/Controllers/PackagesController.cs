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
        
        [HttpPost("")]
        public async Task<IActionResult> RegisterPackage([FromBody] RegisterPackageDto registerPackageDto)
        {
            var command = _mapper.Map<RegisterPackageCommand>(registerPackageDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) Ok() : NotFound();
        }
    }
}