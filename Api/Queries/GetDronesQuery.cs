using System.Collections.Generic;
using Contracts;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}