using System.Collections.Generic;
using MediatR;
using WebApplication.Contracts;

namespace WebApplication.Queries
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}