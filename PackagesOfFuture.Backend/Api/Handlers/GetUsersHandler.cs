using System.Collections.Generic;
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
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        
        public GetUsersHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Set<User>()
                .Include(x => x.Address)
                .ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<ICollection<UserDto>>(users);
        }
    }
}