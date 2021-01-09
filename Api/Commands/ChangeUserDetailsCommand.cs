using Contracts.Responses;
using MediatR;
using Persistance;

namespace Api.Commands
{
    public class ChangeUserDetailsCommand : IRequest<Response<ChangeUserDetailsResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
    }
}