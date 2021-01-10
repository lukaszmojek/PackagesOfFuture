using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class MoveDroneToSortingCommand : IRequest<Response<MoveDroneToSortingResponse>>
    {
        public int DroneId { get; set; }
        public int SortingId { get; set; }
    }
}