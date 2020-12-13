using MediatR;
using WebApplication.Responses;

namespace WebApplication.Controllers
{
    public class AddAddressCommand : IRequest<Response<AddAddressResponse>>
    {
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}