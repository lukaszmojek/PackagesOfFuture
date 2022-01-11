using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class UnregisterUserHandler : IRequestHandler<UnregisterUserCommand, Response<UnregisterUserResponse>>
    {
        private readonly IUserRepository _repository;
        
        public UnregisterUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<UnregisterUserResponse>> Handle(UnregisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            
            _repository.Delete(user);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<UnregisterUserResponse>();
        }
    }
}