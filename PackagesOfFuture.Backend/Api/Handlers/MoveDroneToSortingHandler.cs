using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class MoveDroneToSortingHandler : IRequestHandler<MoveDroneToSortingCommand, Response<MoveDroneToSortingResponse>>
    {
        private readonly IRepository<Drone> _repository;
        private readonly DbContext _dbContext;

        public MoveDroneToSortingHandler(IRepository<Drone> repository, DbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<Response<MoveDroneToSortingResponse>> Handle(MoveDroneToSortingCommand request, CancellationToken cancellationToken)
        {
            var drone = await _dbContext.Set<Drone>()
                .Include(x => x.Sorting)
                .FirstOrDefaultAsync(x => x.Id == request.DroneId, cancellationToken: cancellationToken);
            
            //if (drone.Sorting.Id == request.SortingId)
            //{
            //    return ResponseFactory.CreateFailureResponse<MoveDroneToSortingResponse>(
            //        "Drone already exists in this sorting!");
            //}

            var sorting = await _dbContext.Set<Sorting>()
                .FirstOrDefaultAsync(x => x.Id == request.SortingId, cancellationToken: cancellationToken);
            drone.Sorting = sorting;
            drone.Range = request.Range;
            drone.Model = request.Model;

            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<MoveDroneToSortingResponse>();
        }
    }
}