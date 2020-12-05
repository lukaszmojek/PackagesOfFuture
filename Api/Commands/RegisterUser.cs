using MediatR;

namespace WebApplication.Commands
{
    public class RegisterUser : IRequest<RegisterUserResponse>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}