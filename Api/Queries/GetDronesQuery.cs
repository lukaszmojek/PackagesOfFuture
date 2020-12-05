using System.Collections.Generic;
using MediatR;

namespace WebApplication.Controllers
{
    public class GetDronesQuery : IRequest<ICollection<DroneDto>>
    {
    }
}