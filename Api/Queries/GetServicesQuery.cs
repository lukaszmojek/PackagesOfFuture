using System.Collections.Generic;
using Api.Handlers;
using Contracts.Requests;
using MediatR;

namespace Api.Queries
{
    public class GetServicesQuery : IRequest<ICollection<ServiceDto>>
    {
    }
}