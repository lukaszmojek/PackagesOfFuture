using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class GetPackagesHandler : IRequestHandler<GetPackagesQuery, ICollection<PackageDto>>
    {
        private readonly IRepository<Package> _repository;
        private readonly IMapper _mapper;
        private DbContext _dbContext;

        public GetPackagesHandler(IRepository<Package> repository, IMapper mapper, DbContext dbContext)
        {
            _repository = repository;
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
                    .ToListAsync();

            return this._mapper.Map<ICollection<PackageDto>>(packages);
        }
    }
}