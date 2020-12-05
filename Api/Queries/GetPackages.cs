using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace WebApplication.Queries
{
    public class GetPackages : IRequest<ICollection<PackageDto>>
    {
        
    }
}