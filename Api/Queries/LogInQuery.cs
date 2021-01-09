using Contracts.Responses;
using MediatR;

namespace Api.Queries
{
    public class LogInQuery : IRequest<Response<LogInResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}