namespace Contracts.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public AddressDto Address { get; set; }
    }
}