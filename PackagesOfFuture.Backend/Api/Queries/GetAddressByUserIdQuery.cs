using Contracts.Dtos;
using MediatR;

namespace Api.Controllers;

public class GetAddressByUserIdQuery : IRequest<AddressDto>
{
    public int UserId { get; }

    public GetAddressByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}