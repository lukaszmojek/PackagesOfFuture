namespace Contracts.Dtos
{
    public class CreateAddressDto
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}