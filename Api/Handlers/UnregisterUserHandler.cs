using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using MediatR;
using Persistance.Entities;
using WebApplication.Controllers;
using WebApplication.Factories;
using WebApplication.Responses;

namespace WebApplication.Handlers
{
    public class UnregisterUserHandler : IRequestHandler<UnregisterUserCommand, UnregisterUserResponse>
    {
        private readonly IRepository<User> _repository;
        
        public UnregisterUserHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        
        public async Task<UnregisterUserResponse> Handle(UnregisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            
            _repository.DeleteAsync(user);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<UnregisterUserResponse>();
        }
    }
}