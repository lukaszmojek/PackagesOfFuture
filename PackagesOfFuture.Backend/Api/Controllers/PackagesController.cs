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
        
        /// <summary>
        /// Gets all packages
        /// </summary>
        /// <returns>All packages from database</returns>
        /// <response code="200">When there are packages</response>
        /// <response code="404">If there are no packages</response>
        [HttpGet("")]
        public async Task<ActionResult<ICollection<PackageDto>>> GetPackages()
        {
            var result = await _mediator.Send(new GetPackagesQuery());
            return result.Any() ? (ActionResult<ICollection<PackageDto>>) Ok(result) : NotFound();
        }
        
        /// <summary>
        /// Gets packages for user
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>User packages from database</returns>
        /// <response code="200">When there are packages</response>
        /// <response code="404">If there are no packages</response>
        [HttpGet("user-packages/{userId}")]
        public async Task<ActionResult<ICollection<PackageDto>>> GetUserPackages([FromRoute] int userId)
        {
            var result = await _mediator.Send(new GetUserPackagesQuery() { UserId = userId});
            return result.Any() ? (ActionResult<ICollection<PackageDto>>) Ok(result) : NotFound();
        }
        
        /// <summary>
        /// Registers a new package
        /// </summary>
        /// <param name="registerPackageDto">Representation of package to register</param>
        /// <returns>Nothing. Query GetPackages for current database status</returns>
        /// <response code="204">When package was registered</response>
        /// <response code="400">When error regarding input occurred</response>
        [HttpPost("")]
        public async Task<IActionResult> RegisterPackage([FromBody] RegisterPackageDto registerPackageDto)
        {
            var command = _mapper.Map<RegisterPackageCommand>(registerPackageDto);
            var result = await _mediator.Send(command);
            
            return result.Succeeded ? (IActionResult) Ok() : NotFound();
        }
    }
}