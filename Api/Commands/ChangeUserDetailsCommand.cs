using Contracts.Dtos;
using Contracts.Responses;
using MediatR;
using ResourceEnums;

namespace Api.Commands
{
    public class ChangeUserDetailsCommand : IRequest<Response<ChangeUserDetailsResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
        public AddressDto Address { get; set; }
    }
}