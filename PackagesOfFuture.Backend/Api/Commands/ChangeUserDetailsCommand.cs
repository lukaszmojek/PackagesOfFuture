using Contracts.Dtos;
using Contracts.Responses;
using Data.Entities;
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
        public AddressDto Address { get; set; }
        public User RequestingUser { get; set; }
    }
}