using System.Collections.Generic;

namespace Data.Entities
{
    public class Service : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public virtual ICollection<Package> Packages { get; set; }
    }
}