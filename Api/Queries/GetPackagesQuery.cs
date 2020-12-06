using System.Collections.Generic;
using MediatR;
using WebApplication.Contracts;

namespace WebApplication.Queries
{
    public class GetPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        
    }
}