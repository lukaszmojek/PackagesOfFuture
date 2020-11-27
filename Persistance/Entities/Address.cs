namespace Persistance.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}