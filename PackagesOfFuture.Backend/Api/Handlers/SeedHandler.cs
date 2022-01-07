using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
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
        private readonly IRepository<SupportIssue> _supportIssueRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<Sorting> _sortingRepository;

        public SeedHandler(IRepository<Package> packageRepository, IRepository<Service> serviceRepository, IRepository<Drone> droneRepository, IRepository<Address> addressRepository, IRepository<User> userRepository, IRepository<SupportIssue> supportIssueRepository, IRepository<Payment> paymentRepository, IRepository<Vehicle> vehicleRepository, IRepository<Sorting> sortingRepository)
        {
            _packageRepository = packageRepository;
            _userRepository = userRepository;
            _supportIssueRepository = supportIssueRepository;
            _paymentRepository = paymentRepository;
            _vehicleRepository = vehicleRepository;
            _sortingRepository = sortingRepository;
            _serviceRepository = serviceRepository;
            _droneRepository = droneRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Response<SeedResponse>> Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            if (!await PurgeData())
            {
                return ResponseFactory.CreateFailureResponse<SeedResponse>();
            }
            
            await SeedUsers();
            await SeedAddresses();
            
            var package = new Package
            {
                Id = 1,
                DeliveryDate = DateTime.Now,
                Status = PackageStatus.Delivered,
                Width = 12,
                Height = 12,
                Length = 12,
                Weight = 30,
                DeliveryAddressId = 1,
                ReceiveAddressId = 2,
                Payment = new Payment
                {
                    Status = PaymentStatus.InProgress,
                    Amount = 12.34
                }
            };

            await _packageRepository.AddAsync(package);
            await _packageRepository.SaveChangesAsync();
            Console.WriteLine("Packages seeded");

            return ResponseFactory.CreateSuccessResponse<SeedResponse>();
        }

        private async Task<bool> PurgeData()
        {
            try
            {
                var packages = await _packageRepository.GetAsync();
                if (packages.Count > 0)
                {
                    _packageRepository.DeleteRange(packages);
                    await _packageRepository.SaveChangesAsync();
                    Console.WriteLine("Packages purged");
                }
                
                var users = await _userRepository.GetAsync();
                if (users.Count > 0)
                {
                    _userRepository.DeleteRange(users);
                    await _userRepository.SaveChangesAsync();
                    Console.WriteLine("Users purged");
                }
                
                var drones = await _droneRepository.GetAsync();
                if (drones.Count > 0)
                {
                    _droneRepository.DeleteRange(drones);
                    await _droneRepository.SaveChangesAsync();
                    Console.WriteLine("Drones purged");
                }
                
                var addresses = await _addressRepository.GetAsync();
                if (addresses.Count > 0)
                {
                    _addressRepository.DeleteRange(addresses);
                    await _addressRepository.SaveChangesAsync();
                    Console.WriteLine("Addresses purged");
                }
                
                var services = await _serviceRepository.GetAsync();
                if (services.Count > 0)
                {
                    _serviceRepository.DeleteRange(services);
                    await _serviceRepository.SaveChangesAsync();
                    Console.WriteLine("Services purged");
                }
                
                var payments = await _paymentRepository.GetAsync();
                if (payments.Count > 0)
                {
                    _paymentRepository.DeleteRange(payments);
                    await _paymentRepository.SaveChangesAsync();
                    Console.WriteLine("Payments purged");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private async Task SeedUsers()
        {
            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Łukasz",
                    LastName = "Mojek",
                    Email = "lukasz@pof.com",
                    Password = "test123",
                    Type = UserType.Administrator
                },
                new()
                {
                    Id = 2,
                    FirstName = "Dawid",
                    LastName = "Blaszkiewicz",
                    Email = "dawid@pof.com",
                    Password = "test123",
                    Type = UserType.Administrator
                },
                new()
                {
                    Id = 3,
                    FirstName = "Zbiegniew",
                    LastName = "Gaźnik",
                    Email = "zbych@pof.com",
                    Password = "test123",
                    Type = UserType.Driver
                },
                new()
                {
                    Id = 4,
                    FirstName = "Marysia",
                    LastName = "Znajdek",
                    Email = "marysia@email.com",
                    Password = "test123",
                    Type = UserType.Client
                },
                new()
                {
                    Id = 5,
                    FirstName = "Adam",
                    LastName = "Kiełbasa",
                    Email = "adam@email.com",
                    Password = "test123",
                    Type = UserType.Client
                },
                new()
                {
                    Id = 6,
                    FirstName = "Tomasz",
                    LastName = "Długowłosy",
                    Email = "tomasz@email.com",
                    Password = "test123",
                    Type = UserType.Client
                },
            };
            
            await _userRepository.AddRangeAsync(users);
            await _userRepository.SaveChangesAsync();
            Console.WriteLine("Users seeded");
        }
        
        private async Task SeedAddresses()
        {
            var addresses = new List<Address>
            {
                new()
                {
                    Id = 1,
                    City = "Mielec",
                    HouseAndFlatNumber = "12/3",
                    Street = "Osla laka"
                },
                new()
                {
                    Id = 2,
                    City = "Kraków",
                    HouseAndFlatNumber = "2",
                    Street = "Myślenicka"
                },
                new()
                {
                    Id = 3,
                    City = "Wilcza",
                    HouseAndFlatNumber = "73",
                    Street = "-"
                }
            };
            
            await _addressRepository.AddRangeAsync(addresses);
            await _addressRepository.SaveChangesAsync();
            Console.WriteLine("Addresses seeded");
        }
    }
}