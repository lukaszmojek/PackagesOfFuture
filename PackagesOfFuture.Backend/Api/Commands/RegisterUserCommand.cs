using Contracts.Dtos;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterUserCommand : IRequest<Response<RegisterUserResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }
        public CreateAddressDto Address { get; set; }
    }
}