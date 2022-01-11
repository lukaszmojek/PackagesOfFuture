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
    public class RegisterServiceHandler : IRequestHandler<RegisterServiceCommand, Response<RegisterServiceResponse>>
    {
        private IRepository<Service> _repository;
        private IMapper _mapper;

        public RegisterServiceHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<RegisterServiceResponse>> Handle(RegisterServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request);

            await _repository.AddAsync(service);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterServiceResponse>();
        }
    }
}