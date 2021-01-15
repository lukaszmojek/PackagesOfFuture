using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
        [HttpGet("user-packages/{userId}")]
        public async Task<ActionResult<ICollection<PackageDto>>> GetUserPackages([FromRoute] int userId)
        {
            var result = await _mediator.Send(new GetUserPackagesQuery() { UserId = userId});
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

    public class GetUserPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        public int UserId { get; set; }
    }
    
    public class GetUserPackagesHandler : IRequestHandler<GetUserPackagesQuery, ICollection<PackageDto>>
    {
        private DbContext _dbContext;
        private IMapper _mapper;

        public GetUserPackagesHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<PackageDto>> Handle(GetUserPackagesQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Set<User>()
                .Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            var packages = await _dbContext.Set<Package>()
                .Include(x => x.DeliveryAddress)
                .Include(x => x.ReceiveAddress)
                .Include(x => x.Payment)
                .Where(x => x.DeliveryAddress.Equals(user.Address)
                            || x.ReceiveAddress.Equals(user.Address))
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IList<PackageDto>>(packages);
        }
    }
}