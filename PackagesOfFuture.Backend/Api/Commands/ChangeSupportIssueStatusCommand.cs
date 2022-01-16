using Contracts.Responses;
using MediatR;
using ResourceEnums;

namespace Api.Commands
{
    public class ChangeSupportIssueStatusCommand : IRequest<Response<ChangeSupportIssueStatusResponse>>
    {
        public int Id { get; set; }
        public SupportIssueStatus Status { get; set; }
    }
}