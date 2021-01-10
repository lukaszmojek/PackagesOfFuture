using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class UnregisterUserCommand : IRequest<Response<UnregisterUserResponse>>
    {
        public int UserId { get; set; }   
    }
}