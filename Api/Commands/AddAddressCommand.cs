using MediatR;

namespace WebApplication.Controllers
{
    public class AddAddressCommand : IRequest<AddAddressResponse>
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}