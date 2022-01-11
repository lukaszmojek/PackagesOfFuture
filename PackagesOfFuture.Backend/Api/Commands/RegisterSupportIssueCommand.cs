using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterSupportIssueCommand : IRequest<Response<RegisterSupportIssueResponse>>
    {
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}