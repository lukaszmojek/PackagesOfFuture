using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Api.Queries;
using AutoMapper;
using Contracts.Requests;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

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
            var packages = await _repository.GetAsync();
            return this._mapper.Map<ICollection<PackageDto>>(packages);
        }
    }
}