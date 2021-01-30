using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class GetUserPackagesHandler : IRequestHandler<GetUserPackagesQuery, ICollection<PackageDto>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

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