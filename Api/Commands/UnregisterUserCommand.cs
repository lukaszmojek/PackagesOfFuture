using Contracts.Responses;
using MediatR;
using Persistance;

namespace Api.Commands
{
    public class UnregisterUserCommand : IRequest<Response<UnregisterUserResponse>>
    {
        public int UserId { get; set; }   
    }
}