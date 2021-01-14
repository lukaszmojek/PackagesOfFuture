using Contracts.Responses;
using MediatR;

namespace Api.Controllers
{
    public class ChangeUserPasswordCommand : IRequest<Response<ChangeUserPasswordResponse>>
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}