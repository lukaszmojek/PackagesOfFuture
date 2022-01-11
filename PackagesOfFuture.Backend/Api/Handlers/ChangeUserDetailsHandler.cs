using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class ChangeUserDetailsHandler : IRequestHandler<ChangeUserDetailsCommand, Response<ChangeUserDetailsResponse>>
    {
        private readonly DbContext _dbContext;
        
        public ChangeUserDetailsHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<ChangeUserDetailsResponse>> Handle(ChangeUserDetailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Set<User>()
                               .Include(x => x.Address)
                               .SingleAsync(x => x.Id == command.Id, cancellationToken: cancellationToken)
                           ?? throw new Exception("User does not exist");

                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.Type = command.Type;
                user.Password = command.Password;

                user.Address.City = command.Address.City;
                user.Address.Street = command.Address.Street;
                user.Address.HouseAndFlatNumber = command.Address.HouseAndFlatNumber;
                user.Address.PostalCode = command.Address.PostalCode;
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseFactory.CreateSuccessResponse<ChangeUserDetailsResponse>();
            }
            catch (Exception)
            {
                return ResponseFactory.CreateFailureResponse<ChangeUserDetailsResponse>(); 
            }
        }
    }
}