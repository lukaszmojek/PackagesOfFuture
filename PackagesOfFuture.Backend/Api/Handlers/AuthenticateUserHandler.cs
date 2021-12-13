using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Responses;
using Api.Factories;
using Api.Queries;
using Api.Services;
using AutoMapper;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, Response<AuthenticateUserResponse>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IMapper mapper, DbContext dbContext, IUserService userService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userService = userService;
        }
        
        public async Task<Response<AuthenticateUserResponse>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Set<User>()
                .Include(x => x.Address)
                .SingleOrDefaultAsync(u => u.Email.Equals(request.Email)
                                      && u.Password.Equals(request.Password), cancellationToken: cancellationToken);

            if (user == null)
            {
                ResponseFactory.CreateFailureResponse<AuthenticateUserResponse>();
            }
            
            var token = this._userService.Authenticate(user);
            
            return ResponseFactory.CreateSuccessResponse(new AuthenticateUserResponse {Token = token});
        }
    }
}