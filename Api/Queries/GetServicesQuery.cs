using System.Collections.Generic;
using Api.Handlers;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetServicesQuery : IRequest<ICollection<ServiceDto>>
    {
    }
}