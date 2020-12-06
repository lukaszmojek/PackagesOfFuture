using MediatR;
using WebApplication.Responses;

namespace WebApplication.Controllers
{
    public class MoveDroneToSortingCommand : IRequest<MoveDroneToSortingResponse>
    {
        public int DroneId { get; set; }
        public int SortingId { get; set; }
    }
}