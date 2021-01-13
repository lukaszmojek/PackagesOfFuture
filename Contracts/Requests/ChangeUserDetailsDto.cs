using ResourceEnums;

namespace Contracts.Requests
{
    public class ChangeUserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
    }
}