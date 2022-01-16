using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Factories;
using Contracts.Responses;
using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ResourceEnums;
#pragma warning disable CS1591

namespace Api.Handlers;

public class ChangeUserDetailsHandler : 
        IRequestHandler<ChangeUserDetailsCommand, Response<ChangeUserDetailsResponse>>
{
    private readonly DbContext _dbContext;

    public ChangeUserDetailsHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response<ChangeUserDetailsResponse>> Handle(
        ChangeUserDetailsCommand command,
        CancellationToken cancellationToken
    ) {
        try
        {
            var user = await _dbContext.Set<User>()
                           .Include(x => x.Address)
                           .SingleAsync(x => x.Id == command.Id, cancellationToken)
                       ?? throw new Exception("User does not exist");

            if (CanEditDetails(command, user.Id))
            {
                var message =
                    $"User with id {command.RequestingUser.Id} tried " +
                    $"to edit user with id {user.Id} as an not administrator user";
                throw new UnauthorizedAccessException(message);
            }

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;

            user.Address.City = command.Address.City;
            user.Address.Street = command.Address.Street;
            user.Address.HouseAndFlatNumber = command.Address.HouseAndFlatNumber;
            user.Address.PostalCode = command.Address.PostalCode;

            if (user.Type != command.Type)
            {
                if (command.RequestingUser.Type != UserType.Administrator)
                {
                    var message =
                        $"User with id {command.RequestingUser.Id} tried to change " +
                        $"type of the user with id {user.Id} as an not administrator user";
                    throw new UnauthorizedAccessException(message);
                }

                user.Type = command.Type;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ResponseFactory.CreateSuccessResponse<ChangeUserDetailsResponse>();
        }
        catch (UnauthorizedAccessException e)
        {
            return ResponseFactory.CreateFailureResponse<ChangeUserDetailsResponse>(e.Message);
        }
        catch (Exception e)
        {
            return ResponseFactory.CreateFailureResponse<ChangeUserDetailsResponse>();
        }
    }

    private bool CanEditDetails(ChangeUserDetailsCommand command, int userId) => 
        !command.RequestingUser.Id.Equals(userId) 
        && command.RequestingUser.Type != UserType.Administrator;
}