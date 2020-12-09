using System.Collections.Generic;
using Api.Contracts;
using MediatR;
using WebApplication.Contracts;

namespace WebApplication.Queries
{
    public class GetPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        
    }
}