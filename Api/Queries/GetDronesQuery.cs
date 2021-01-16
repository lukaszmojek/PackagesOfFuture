using System.Collections.Generic;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}