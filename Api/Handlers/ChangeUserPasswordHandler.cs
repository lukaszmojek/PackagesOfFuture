using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Controllers;
using Api.Factories;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class ChangeUserPasswordHandler : IRequestHandler<ChangeUserPasswordCommand, Response<ChangeUserPasswordResponse>>
    {
        private readonly IRepository<User> _repository;

        public ChangeUserPasswordHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Response<ChangeUserPasswordResponse>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ArgumentException(nameof(request.UserId));
            }

            user.Password = request.NewPassword;
            await _repository.SaveChangesAsync();
            
            return  ResponseFactory.CreateSuccessResponse<ChangeUserPasswordResponse>();
        }
    }
}