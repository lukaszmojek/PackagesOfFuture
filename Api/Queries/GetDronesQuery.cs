using System.Collections.Generic;
using Api.Contracts;
using MediatR;

namespace Api.Queries
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}