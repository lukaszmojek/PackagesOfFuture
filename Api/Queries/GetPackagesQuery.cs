using System.Collections.Generic;
using Api.Contracts;
using MediatR;

namespace Api.Queries
{
    public class GetPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        
    }
}