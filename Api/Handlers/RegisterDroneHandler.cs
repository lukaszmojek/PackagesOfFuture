using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using AutoMapper;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class RegisterDroneHandler : IRequestHandler<RegisterDroneCommand, Response<RegisterDroneResponse>>
    {
        private readonly IRepository<Drone> _repository;
        private readonly IMapper _mapper;

        public RegisterDroneHandler(IMapper mapper, IRepository<Drone> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<RegisterDroneResponse>> Handle(RegisterDroneCommand request, CancellationToken cancellationToken)
        {
            var drone = _mapper.Map<Drone>(request);

            await _repository.AddAsync(drone);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterDroneResponse>();
        }
    }
}