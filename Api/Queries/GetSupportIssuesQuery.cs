using System.Collections.Generic;
using Contracts.Requests;
using MediatR;

namespace Api.Controllers
{
    public class GetSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
    }
}