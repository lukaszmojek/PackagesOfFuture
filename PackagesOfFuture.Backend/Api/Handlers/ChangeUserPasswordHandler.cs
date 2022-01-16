using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using Contracts.Responses;
using Infrastructure.Repositories;
using MediatR;

namespace Api.Handlers
{
    public class ChangeUserPasswordHandler : IRequestHandler<ChangeUserPasswordCommand, Response<ChangeUserPasswordResponse>>
    {
        private readonly IUserRepository _repository;

        public ChangeUserPasswordHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ChangeUserPasswordResponse>> Handle(
            ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetByIdAsync(request.UserId);

                if (user == null)
                {
                    throw new ArgumentException(nameof(request.UserId));
                }

                if (user.Password != request.OldPassword)
                {
                    throw new ArgumentException(nameof(request.OldPassword));
                }

                user.Password = request.NewPassword;
                await _repository.SaveChangesAsync();

                return ResponseFactory.CreateSuccessResponse<ChangeUserPasswordResponse>();
            }
            catch (ArgumentException e)
            {
                return ResponseFactory.CreateFailureResponse<ChangeUserPasswordResponse>(e.Message);
            }
            catch (Exception e)
            {
                return ResponseFactory.CreateFailureResponse<ChangeUserPasswordResponse>(e.Message);
            }
        }
    }
}