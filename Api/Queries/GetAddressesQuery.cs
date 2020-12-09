using System.Collections.Generic;
using MediatR;
using Api.Contracts;

namespace WebApplication.Queries
{
    public class GetAddressesQuery : IRequest<ICollection<AddressDto>>
    {
    }
}