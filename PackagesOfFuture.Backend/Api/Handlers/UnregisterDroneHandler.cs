using System.Threading;
using System.Threading.Tasks;
using Api.Factories;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Controllers;

public class UnregisterDroneHandler : IRequestHandler<UnregisterDroneCommand, Response<UnregisterDroneResponse>>
{
    private IRepository<Drone> _repository;

    public UnregisterDroneHandler(IRepository<Drone> repository)
    {
        _repository = repository;
    }

    public async Task<Response<UnregisterDroneResponse>> Handle(UnregisterDroneCommand request, CancellationToken cancellationToken)
    {
        var drone = await _repository.GetByIdAsync(request.Id);
        _repository.Delete(drone);
        await _repository.SaveChangesAsync();
            
        return ResponseFactory.CreateSuccessResponse<UnregisterDroneResponse>();
    }
}