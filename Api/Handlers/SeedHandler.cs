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
    public class SeedHandler : IRequestHandler<SeedCommand, SeedResponse>
    {
        private readonly IRepository<Package> _repository;

        public SeedHandler(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public async Task<SeedResponse> Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            var user = new User() { };
             var deliveryAddress = new Address(){Id = 13, City = "Dupowo", HouseAndFlatNumber = "12/3", Street = "Osla laka"};
             var receiveAddress = new Address(){Id = 14, City = "Chujowo", HouseAndFlatNumber = "69", Street = "Rowek"};
             var payment = new Payment(){};
            
             var package = new Package()
             {
                 Id = 10,
                 DeliveryDate = DateTime.Now,
                 Status = PackageStatus.Delivered,
                 Width = 12,
                 Height = 12,
                 Length = 12,
                 Weight = 30,
                 DeliveryAddress = deliveryAddress,
                 ReceiveAddress = receiveAddress,
                 Payment = payment
             };
            
            
            await _repository.AddAsync(package);
            await _repository.SaveChangesAsync();

            return new SeedResponse() {Succeeded = true};
        }
    }
}