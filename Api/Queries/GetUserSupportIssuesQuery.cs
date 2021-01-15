using System.Collections.Generic;
using MediatR;

namespace Api.Controllers
{
    public class GetUserSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
        public int UserId { get; set; }
    }
}