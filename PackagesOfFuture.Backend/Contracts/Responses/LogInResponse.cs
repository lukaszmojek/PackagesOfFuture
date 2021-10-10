using Contracts.Dtos;
using ResourceEnums;

namespace Contracts.Responses
{
    public class LogInResponse : IResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public AddressDto Address { get; set; }
    }
}