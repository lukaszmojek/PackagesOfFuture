using MediatR;

namespace WebApplication.Controllers
{
    public class UnregisterUserCommand : IRequest<UnregisterUserResponse>
    {
        public int UserId { get; set; }   
    }
}