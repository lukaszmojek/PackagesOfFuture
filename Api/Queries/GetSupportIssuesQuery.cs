using System.Collections.Generic;
using MediatR;

namespace Api.Controllers
{
    public class GetSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
    }
}