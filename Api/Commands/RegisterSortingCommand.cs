using Contracts.Dtos;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class RegisterSortingCommand : IRequest<Response<RegisterSortingResponse>>
    {
        public string Name { get; set; }
        public CreateAddressDto Address { get; set; }
    }
}