using System.Collections.Generic;
using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>
    {
    }
}