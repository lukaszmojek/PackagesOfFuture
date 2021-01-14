using System.Collections.Generic;

namespace Data.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        
        public virtual ICollection<Package> PackagesReceived { get; set; }
        public virtual ICollection<Package> PackagesDelivered { get; set; }
    }
}