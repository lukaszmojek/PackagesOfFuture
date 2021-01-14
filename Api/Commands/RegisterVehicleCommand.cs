using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterVehicleCommand : IRequest<Response<RegisterVehicleResponse>>
    {
        public string Model { get; set; }
    }
}