using System.Collections.Generic;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetVehiclesQuery : IRequest<ICollection<VehicleDto>>
    {
    }
}