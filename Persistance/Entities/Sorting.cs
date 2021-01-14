using System.Collections.Generic;

namespace Data.Entities
{
    public class Sorting : Entity
    {
        public string Name { get; set; }
        
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Drone> Drones { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}