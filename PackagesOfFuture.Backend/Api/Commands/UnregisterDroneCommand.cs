using Contracts.Responses;
using MediatR;

namespace Api.Controllers;

public class UnregisterDroneCommand : IRequest<Response<UnregisterDroneResponse>>
{
    public int Id { get; set; }
}