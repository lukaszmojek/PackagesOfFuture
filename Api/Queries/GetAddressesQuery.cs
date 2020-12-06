using System.Collections.Generic;
using MediatR;
using WebApplication.Contracts;

namespace WebApplication.Queries
{
    public class GetAddressesQuery : IRequest<ICollection<AddressDto>>
    {
    }
}