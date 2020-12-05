using System;

namespace Persistance.Entities
{
    public class Package : Entity
    {
        public DateTime DeliveryDate { get; set; }
        public PackageStatus Status { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
    }
}