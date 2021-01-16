using System.Collections.Generic;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
    }
}