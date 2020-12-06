using MediatR;
using WebApplication.Responses;

namespace WebApplication.Controllers
{
    public class UnregisterUserCommand : IRequest<UnregisterUserResponse>
    {
        public int UserId { get; set; }   
    }
}