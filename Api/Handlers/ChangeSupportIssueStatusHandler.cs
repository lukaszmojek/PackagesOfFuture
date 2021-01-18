using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Controllers;
using Api.Factories;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class ChangeSupportIssueStatusHandler : IRequestHandler<ChangeSupportIssueStatusCommand, Response<ChangeSupportIssueStatusResponse>>
    {
        private readonly IRepository<SupportIssue> _repository;

        public ChangeSupportIssueStatusHandler(IRepository<SupportIssue> repository)
        {
            _repository = repository;
        }

        public async Task<Response<ChangeSupportIssueStatusResponse>> Handle(ChangeSupportIssueStatusCommand request, CancellationToken cancellationToken)
        {
            var supportIssue = await _repository.GetByIdAsync(request.Id);
            
            supportIssue.Status = request.Status;
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<ChangeSupportIssueStatusResponse>();
        }
    }
}