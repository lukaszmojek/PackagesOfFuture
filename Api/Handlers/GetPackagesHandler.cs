using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Queries;

namespace WebApplication.Handlers
{
    public class GetPackagesHandler : IRequestHandler<GetPackages, ICollection<PackageDto>>
    {
        private readonly IRepository<Package> _repository;
        private readonly IMapper _mapper;

        public GetPackagesHandler(IRepository<Package> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<PackageDto>> Handle(GetPackages request, CancellationToken cancellationToken)
        {
            var packages = await _repository.GetAsync();
            return this._mapper.Map<ICollection<PackageDto>>(packages);
        }
    }
}