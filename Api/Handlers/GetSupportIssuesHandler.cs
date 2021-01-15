using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Requests;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Api.Controllers
{
    public class GetSupportIssuesHandler : IRequestHandler<GetSupportIssuesQuery, ICollection<SupportIssueDto>>
    {
        private IRepository<SupportIssue> _repository;
        private DbContext _dbContext;
        private IMapper _mapper;

        public GetSupportIssuesHandler(IMapper mapper, IRepository<SupportIssue> repository, DbContext dbContext)
        {
            _mapper = mapper;
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<ICollection<SupportIssueDto>> Handle(GetSupportIssuesQuery request, CancellationToken cancellationToken)
        {
            var supportIssues = await _dbContext.Set<SupportIssue>()
                .ToListAsync();

            return _mapper.Map<ICollection<SupportIssueDto>>(supportIssues);
        }
    }
}