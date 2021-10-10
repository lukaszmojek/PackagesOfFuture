using Contracts.Dtos;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterPackageCommand : IRequest<Response<RegisterPackageResponse>>
    {
        public AddressDto DeliveryAddress { get; set; }
        public AddressDto ReceiveAddress { get; set; }
        public PackageDetailsDto Package { get; set; }
        public int ServiceId { get; set; }
        public PaymentDto Payment { get; set; }
    }
}