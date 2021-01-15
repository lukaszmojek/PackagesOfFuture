using Api.Controllers;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class ChangeUserPasswordCommand : IRequest<Response<ChangeUserPasswordResponse>>
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}