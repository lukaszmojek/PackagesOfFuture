using System.Collections.Generic;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
    }
}