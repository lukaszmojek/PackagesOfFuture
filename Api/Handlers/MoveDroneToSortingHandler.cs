using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Controllers;
using Api.Factories;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using Api.Responses;

namespace Api.Handlers
{
    public class MoveDroneToSortingHandler : IRequestHandler<MoveDroneToSortingCommand, Response<MoveDroneToSortingResponse>>
    {
        private readonly IRepository<Drone> _repository;

        public MoveDroneToSortingHandler(IRepository<Drone> repository)
        {
            _repository = repository;
        }

        public async Task<Response<MoveDroneToSortingResponse>> Handle(MoveDroneToSortingCommand request, CancellationToken cancellationToken)
        {
            var drone = await _repository.GetByIdAsync(request.DroneId);

            if (drone.Sorting.Id == request.SortingId)
            {
                return ResponseFactory.CreateFailureResponse<MoveDroneToSortingResponse>(
                    "Drone already exists in this sorting!");
            }

            drone.Sorting.Id = request.DroneId;
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<MoveDroneToSortingResponse>();
        }
    }
}