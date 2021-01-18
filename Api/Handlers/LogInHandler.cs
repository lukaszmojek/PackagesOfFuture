using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Responses;
using Api.Factories;
using Api.Queries;
using AutoMapper;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class LogInHandler : IRequestHandler<LogInQuery, Response<LogInResponse>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public LogInHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public async Task<Response<LogInResponse>> Handle(LogInQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Set<User>()
                .Include(x => x.Address)
                .SingleOrDefaultAsync(u => u.Email.Equals(request.Email)
                                      && u.Password.Equals(request.Password), cancellationToken: cancellationToken);

            return user == null 
                ? ResponseFactory.CreateFailureResponse<LogInResponse>() 
                : ResponseFactory.CreateSuccessResponse(_mapper.Map<LogInResponse>(user));
        }
    }
}