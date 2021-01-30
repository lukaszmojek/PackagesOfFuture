using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using AutoMapper;
using Contracts.Dtos;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class GetUserSupportIssuesHandler : IRequestHandler<GetUserSupportIssuesQuery, ICollection<SupportIssueDto>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserSupportIssuesHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ICollection<SupportIssueDto>> Handle(GetUserSupportIssuesQuery request, CancellationToken cancellationToken)
        {
            var supportIssues = await _dbContext.Set<SupportIssue>()
                .Include(x => x.User)
                .Where(x => x.User.Id == request.UserId)
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<ICollection<SupportIssueDto>>(supportIssues);
        }
    }
}