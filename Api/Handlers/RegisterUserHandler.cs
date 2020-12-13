using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Commands;
using WebApplication.Factories;
using WebApplication.Responses;

namespace WebApplication.Handlers
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