using System.Collections.Generic;
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
    public class GetSortingsHandler : IRequestHandler<GetSortingsQuery, ICollection<SortingDto>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSortingsHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<SortingDto>> Handle(GetSortingsQuery request, CancellationToken cancellationToken)
        {
            var sortings = await this._dbContext.Set<Sorting>()
                .Include(x => x.Address)
                .Include(x => x.Packages)
                .Include(x => x.Drones)
                .Include(x => x.Vehicles)
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<ICollection<SortingDto>>(sortings);
        }
    }
}