using MediatR;
using Api.Responses;

namespace Api.Queries
{
    public class LogInQuery : IRequest<Response<LogInResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}