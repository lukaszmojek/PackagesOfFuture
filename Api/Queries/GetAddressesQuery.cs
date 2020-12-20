using System.Collections.Generic;
using MediatR;
using Contracts;
using Contracts.Requests;

namespace Api.Queries
{
    public class GetAddressesQuery : IRequest<ICollection<AddressDto>>
    {
    }
}