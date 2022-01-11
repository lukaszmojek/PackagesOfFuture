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
    public class GetSupportIssuesHandler : IRequestHandler<GetSupportIssuesQuery, ICollection<SupportIssueDto>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSupportIssuesHandler(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ICollection<SupportIssueDto>> Handle(GetSupportIssuesQuery request, CancellationToken cancellationToken)
        {
            var supportIssues = await _dbContext.Set<SupportIssue>()
                .Include(x => x.User)
                .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<ICollection<SupportIssueDto>>(supportIssues);
        }
    }
}