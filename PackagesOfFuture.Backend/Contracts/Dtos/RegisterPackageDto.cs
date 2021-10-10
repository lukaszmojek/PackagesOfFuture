namespace Contracts.Dtos
{
    public class RegisterPackageDto
    {
        public AddressDto DeliveryAddress { get; set; }
        public AddressDto ReceiveAddress { get; set; }
        public PackageDetailsDto Package { get; set; }
        public int ServiceId { get; set; }
        public CreatePaymentDto Payment { get; set; }
    }
}