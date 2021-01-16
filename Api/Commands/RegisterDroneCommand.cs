using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterDroneCommand : IRequest<Response<RegisterDroneResponse>>
    {
        public string Model { get; set; }
        public int Range { get; set; }
        public int SortingId { get; set; }
    }
}