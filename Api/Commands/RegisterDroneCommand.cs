using MediatR;
using WebApplication.Responses;

namespace WebApplication.Controllers
{
    public class RegisterDroneCommand : IRequest<RegisterDroneResponse>
    {
        public string Model { get; set; }
        public int Range { get; set; }
    }
}