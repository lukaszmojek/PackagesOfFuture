using System;
using ResourceEnums;

namespace Data.Entities
{
    public class Package : Entity
    {
        public DateTime DeliveryDate { get; set; }
        public PackageStatus Status { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        
        public Address DeliveryAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Address ReceiveAddress { get; set; }
        public int ReceiveAddressId { get; set; }
        
        public virtual Service Service { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Sorting Sorting { get; set; }
    }
}