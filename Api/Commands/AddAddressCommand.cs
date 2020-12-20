using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class AddAddressCommand : IRequest<Response<AddAddressResponse>>
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}