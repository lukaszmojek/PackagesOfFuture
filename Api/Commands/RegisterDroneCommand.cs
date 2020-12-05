using MediatR;

namespace WebApplication.Controllers
{
    public class RegisterDroneCommand : IRequest<RegisterDroneResponse>
    {
        public string Model { get; set; }
        public int Range { get; set; }
    }
}