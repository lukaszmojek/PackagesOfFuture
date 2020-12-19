using System.Collections.Generic;
using MediatR;
using Api.Contracts;

namespace Api.Queries
{
    public class GetAddressesQuery : IRequest<ICollection<AddressDto>>
    {
    }
}