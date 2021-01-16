using System.Collections.Generic;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetUserPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        public int UserId { get; set; }
    }
}