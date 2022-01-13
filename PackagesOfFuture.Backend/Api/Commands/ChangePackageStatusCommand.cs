using Contracts.Responses;
using MediatR;

namespace Api.Commands
{
    public class ChangePackageStatusCommand : IRequest<Response<ChangePackageStatusResponse>>
    {
        public int PackageId { get; set; }
        public int StatusId { get; set; }
    }
}
