using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using MediatR;
using Persistance;
using Persistance.Entities;
using WebApplication.Commands;
using WebApplication.Responses;

namespace WebApplication.Handlers
{
    public class SeedHandler : IRequestHandler<Seed, SeedResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Package> _repository;

        public SeedHandler(IUnitOfWork unitOfWork, IRepository<Package> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<SeedResponse> Handle(Seed request, CancellationToken cancellationToken)
        {
            var packages = new List<Package>()
            {
                new Package() { DeliveryDate = DateTime.Now, Status = PackageStatus.Delivered, Width = 12, Height = 12, Length = 12, Weight = 30}
            };

            await _repository.AddRangeAsync(packages);
            _unitOfWork.SaveChanges();

            return new SeedResponse() {Succeded = true};
        }
    }
}