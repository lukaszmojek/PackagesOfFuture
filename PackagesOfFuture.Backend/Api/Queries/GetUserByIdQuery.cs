using Contracts.Dtos;
using MediatR;

namespace Api.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; }

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
