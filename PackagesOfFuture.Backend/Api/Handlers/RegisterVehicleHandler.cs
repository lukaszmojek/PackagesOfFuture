using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class RegisterVehicleHandler : IRequestHandler<RegisterVehicleCommand, Response<RegisterVehicleResponse>>
    {
        private IRepository<Vehicle> _repository;
        private IMapper _mapper;

        public RegisterVehicleHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<RegisterVehicleResponse>> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<Vehicle>(request);

            await _repository.AddAsync(vehicle);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterVehicleResponse>();
        }
    }
}