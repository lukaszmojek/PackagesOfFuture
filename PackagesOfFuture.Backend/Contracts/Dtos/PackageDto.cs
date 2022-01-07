using System;
using ResourceEnums;

namespace Contracts.Dtos
{
    public class PackageDto
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public PackageStatus Status { get; set; }
        
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        
        public PaymentDto Payment { get; set; }
        public AddressDto DeliveryAddress { get; set; }
        public AddressDto ReceiveAddress { get; set; }

        public int DeliveryAddressId { get; set; }
        public int ReceiveAddressId { get; set; }
    }
}