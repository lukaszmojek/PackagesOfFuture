using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Sorting : Entity
    {
        public string Name { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Drone> Drones { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}