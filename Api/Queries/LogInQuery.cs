using MediatR;
using WebApplication.Responses;

namespace WebApplication.Queries
{
    public class LogInQuery : IRequest<LogInResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}