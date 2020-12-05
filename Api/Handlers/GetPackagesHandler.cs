using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using WebApplication.Queries;

namespace WebApplication.Handlers
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