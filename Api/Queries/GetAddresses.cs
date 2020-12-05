using System.Collections.Generic;
using MediatR;

namespace WebApplication.Controllers
{
    public class GetAddresses : IRequest<ICollection<AddressDto>>
    {
    }
}