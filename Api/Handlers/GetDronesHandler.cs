using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Infrastructure;
using MediatR;
using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class GetDronesHandler : IRequestHandler<GetDronesQuery, ICollection<DroneDto>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDronesHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ICollection<DroneDto>> Handle(GetDronesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<DroneDto>>(await _dbContext.Set<Drone>().Include(x=>x.Sorting).ToListAsync());
        }
    }
}