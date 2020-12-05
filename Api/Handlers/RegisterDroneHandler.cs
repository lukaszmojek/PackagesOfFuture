using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Factories;

namespace WebApplication.Controllers
{
    public class RegisterDroneHandler : IRequestHandler<RegisterDroneCommand, RegisterDroneResponse>
    {
        private readonly IRepository<Drone> _repository;
        private readonly IMapper _mapper;

        public RegisterDroneHandler(IMapper mapper, IRepository<Drone> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RegisterDroneResponse> Handle(RegisterDroneCommand request, CancellationToken cancellationToken)
        {
            var drone = _mapper.Map<Drone>(request);

            await _repository.AddAsync(drone);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterDroneResponse>();
        }
    }
}