using System.Collections.Generic;
using Api.Contracts;
using MediatR;

namespace Api.Queries
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>
    {
    }
}