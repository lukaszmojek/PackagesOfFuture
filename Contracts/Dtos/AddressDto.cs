namespace Contracts.Dtos
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"{this.Street} {this.HouseAndFlatNumber} {this.PostalCode} {this.City}";
        }
    }
}