using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class GetPackagesHandler : IRequestHandler<GetPackagesQuery, ICollection<PackageDto>>
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public GetPackagesHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ICollection<PackageDto>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
        {
            var packages = 
                await _dbContext.Set<Package>()
                    .Include(x => x.Payment)
                    .Include(x => x.DeliveryAddress)
                    .Include(x => x.ReceiveAddress)
                    .ToListAsync(cancellationToken: cancellationToken);

            return this._mapper.Map<ICollection<PackageDto>>(packages);
        }
    }
}