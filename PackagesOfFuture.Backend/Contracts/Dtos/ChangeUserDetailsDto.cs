namespace Contracts.Dtos
{
    public class ChangeUserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public AddressDto Address { get; set; }
    }
}