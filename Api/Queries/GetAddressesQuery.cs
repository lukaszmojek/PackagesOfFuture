using System.Collections.Generic;
using MediatR;

namespace WebApplication.Controllers
{
    public class GetAddressesQuery : IRequest<ICollection<AddressDto>>
    {
    }
}