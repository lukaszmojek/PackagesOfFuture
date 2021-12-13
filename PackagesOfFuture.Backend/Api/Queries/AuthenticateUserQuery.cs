using Contracts.Responses;
using MediatR;

namespace Api.Queries
{
    public class AuthenticateUserQuery : IRequest<Response<AuthenticateUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}