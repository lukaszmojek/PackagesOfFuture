using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Auth;
using Contracts.Responses;
using Api.Factories;
using Api.Queries;
using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, Response<AuthenticateUserResponse>>
    {
        private readonly DbContext _dbContext;
        private readonly IUserService _userService;

        public AuthenticateUserHandler(DbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }
        
        public async Task<Response<AuthenticateUserResponse>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    var errorMessage = "Email and Password have to be provided!";
                    throw new ArgumentException(errorMessage);
                }
            
                var user = await _dbContext.Set<User>()
                    .SingleOrDefaultAsync(u => u.Email.Equals(request.Email)
                                               && u.Password.Equals(request.Password), cancellationToken: cancellationToken);

                if (user == null)
                {
                    var errorMessage = "User with provided credentials do not exist!";
                    throw new ArgumentException(errorMessage);
                }

                var token = this._userService.Authenticate(user);
            
                return ResponseFactory.CreateSuccessResponse(new AuthenticateUserResponse {Token = token});
            }
            catch (ArgumentException e)
            {
                return ResponseFactory.CreateFailureResponse<AuthenticateUserResponse>(e.Message);
            }
        }
    }
}