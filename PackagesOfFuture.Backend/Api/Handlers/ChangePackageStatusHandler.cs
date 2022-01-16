using Api.Commands;
using Api.Factories;
using AutoMapper;
using Contracts.Responses;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;
using ResourceEnums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public class ChangePackageStatusHandler : IRequestHandler<ChangePackageStatusCommand, Response<ChangePackageStatusResponse>>
    {
        private readonly IRepository<Package> _packageRepository;

        public ChangePackageStatusHandler(IRepository<Package> packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<Response<ChangePackageStatusResponse>> Handle(ChangePackageStatusCommand request, CancellationToken cancellationToken)
        {
            var packages = await _packageRepository.GetAsync();

            var pack = packages.First(x => x.Id == request.PackageId);
            pack.Status = (PackageStatus)request.StatusId;

            await _packageRepository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<ChangePackageStatusResponse>();
        }
    }
}
