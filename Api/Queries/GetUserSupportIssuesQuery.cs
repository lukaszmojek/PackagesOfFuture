using System.Collections.Generic;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetUserSupportIssuesQuery : IRequest<ICollection<SupportIssueDto>>
    {
        public int UserId { get; set; }
    }
}