using System.Collections.Generic;
using Api.Contracts;
using MediatR;
using WebApplication.Contracts;

namespace WebApplication.Queries
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}