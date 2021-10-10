using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Address : Entity, IEquatable<Address>
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        
        public virtual ICollection<Package> PackagesReceived { get; set; }
        public virtual ICollection<Package> PackagesDelivered { get; set; }

        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Street == other.Street 
                   && HouseAndFlatNumber == other.HouseAndFlatNumber
                   && City == other.City
                   && PostalCode == other.PostalCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, HouseAndFlatNumber, City, PostalCode, PackagesReceived, PackagesDelivered);
        }
    }
}