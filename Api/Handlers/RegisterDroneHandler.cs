using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Controllers;
using WebApplication.Factories;
using WebApplication.Responses;

namespace WebApplication.Handlers
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