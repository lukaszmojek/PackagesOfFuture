using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using AutoMapper;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response<RegisterUserResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        
        public RegisterUserHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var usersInDatabase = await _repository.GetAsync();

            if (usersInDatabase.FirstOrDefault(x => x.Email.Equals(request.Email)) != null)
            {
                return ResponseFactory.CreateFailureResponse<RegisterUserResponse>("Mail już znajduje się w bazie!");
            }
            
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<RegisterUserResponse>();
        }
    }
}