using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using MediatR;
using ResourceEnums;

namespace Api.Handlers
{
    public class SeedHandler : IRequestHandler<SeedCommand, Response<SeedResponse>>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<Drone> _droneRepository;
        private readonly IRepository<Address> _addressRepository;

        public SeedHandler(IRepository<Package> packageRepository, IRepository<Service> serviceRepository, IRepository<Drone> droneRepository, IRepository<Address> addressRepository, IRepository<User> userRepository)
        {
            _packageRepository = packageRepository;
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _droneRepository = droneRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Response<SeedResponse>> Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Dawid",
                    LastName = "Blaszkiewicz",
                    Email = "dawid@gmail.com",
                    //Type = UserType.Client
                }
            };
            
            var payments = new List<Payment>
            {

            };
            
            var addresses = new List<Address>
            {
                new Address
                {
                    Id = 13,
                    City = "Dupowo",
                    HouseAndFlatNumber = "12/3",
                    Street = "Osla laka"
                },
                new Address
                {
                    Id = 14,
                    City = "Chujowo",
                    HouseAndFlatNumber = "69",
                    Street = "Rowek"
                }
            };
            var package = new Package
            {
                DeliveryDate = DateTime.Now,
                Status = PackageStatus.Delivered,
                Width = 12,
                Height = 12,
                Length = 12,
                Weight = 30,
                DeliveryAddressId = 13,
                ReceiveAddressId = 14,
                Payment = new Payment
                {
                    Status = PaymentStatus.InProgress,
                    Amount = 12.34
                }
            };
            
            await _packageRepository.AddAsync(package);
            await _packageRepository.SaveChangesAsync();

            return ResponseFactory.CreateSuccessResponse<SeedResponse>();
        }
    }
}