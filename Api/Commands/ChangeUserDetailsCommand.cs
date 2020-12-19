using Api.Responses;
using MediatR;

namespace Api.Commands
{
    public class ChangeUserDetailsCommand : IRequest<Response<ChangeUserDetailsResponse>>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
    }
}