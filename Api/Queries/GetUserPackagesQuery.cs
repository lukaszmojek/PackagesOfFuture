using System.Collections.Generic;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetUserPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        public int UserId { get; set; }
    }
}