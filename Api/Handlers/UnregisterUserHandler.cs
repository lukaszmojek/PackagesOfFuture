using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class UnregisterUserHandler : IRequestHandler<UnregisterUserCommand, Response<UnregisterUserResponse>>
    {
        private readonly IRepository<User> _repository;
        
        public UnregisterUserHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<UnregisterUserResponse>> Handle(UnregisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            
            _repository.DeleteAsync(user);
            await _repository.SaveChangesAsync();
            
            return ResponseFactory.CreateSuccessResponse<UnregisterUserResponse>();
        }
    }
}