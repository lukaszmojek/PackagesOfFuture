using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using AutoMapper;
using Data.Entities;
using MediatR;
using System;
using Infrastructure.Repositories;

namespace Api.Handlers
{
    public class RegisterDroneHandler : IRequestHandler<RegisterDroneCommand, Response<RegisterDroneResponse>>
    {
        private readonly IRepository<Drone> _repository;
        private readonly IRepository<Sorting> _repositoryS;
        private readonly IMapper _mapper;

        public RegisterDroneHandler(IMapper mapper, IRepository<Drone> repository, IRepository<Sorting> repositoryS)
        {
            _repository = repository;
            _repositoryS = repositoryS;
            _mapper = mapper;
        }

        public async Task<Response<RegisterDroneResponse>> Handle(RegisterDroneCommand request, CancellationToken cancellationToken)
        {
            var sorting = await _repositoryS.GetByIdAsync(request.SortingId) ?? throw new ArgumentException(nameof(request.SortingId));
            var drone = _mapper.Map<Drone>(request);

            drone.Sorting = sorting;
            await _repository.AddAsync(drone);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterDroneResponse>();
        }
    }
}