using System.Collections.Generic;
using MediatR;

namespace WebApplication.Queries
{
    public class GetPackagesQuery : IRequest<ICollection<PackageDto>>
    {
        
    }
}