using System.Collections.Generic;
using Contracts.Requests;
using MediatR;

namespace Api.Controllers
{
    public class GetUserSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
        public int UserId { get; set; }
    }
}