using MediatR;
using Api.Responses;

namespace Api.Commands
{
    public class RegisterUserCommand : IRequest<Response<RegisterUserResponse>>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }
    }
}