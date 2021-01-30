using Contracts.Dtos;
using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class ChangeSortingDetailsCommand : IRequest<Response<ChangeSortingDetailsResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}