using Api.Handlers;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterServiceCommand : IRequest<Response<RegisterServiceResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}