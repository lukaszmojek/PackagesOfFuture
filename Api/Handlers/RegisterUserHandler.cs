using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Commands;

namespace WebApplication.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, RegisterUserResponse>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        
        public RegisterUserHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<RegisterUserResponse> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _repository.AddAsync(user);
            
            return new RegisterUserResponse() {Succeded = true};
        }
    }
}