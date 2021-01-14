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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response<RegisterUserResponse>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        
        public RegisterUserHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterUserResponse>();
        }
    }
}