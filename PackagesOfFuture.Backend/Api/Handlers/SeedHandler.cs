using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Contracts.Responses;
using Api.Factories;
using Data.Entities;
using Infrastructure.Repositories;
using MediatR;
using ResourceEnums;

namespace Api.Handlers
{
    public class SeedHandler : IRequestHandler<SeedCommand, Response<SeedResponse>>
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<Drone> _droneRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<SupportIssue> _supportIssueRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<Sorting> _sortingRepository;

        public SeedHandler(
            IRepository<Package> packageRepository, 
            IRepository<Service> serviceRepository, 
            IRepository<Drone> droneRepository, 
            IRepository<Address> addressRepository, 
            IUserRepository userRepository, 
            IRepository<SupportIssue> supportIssueRepository,
            IRepository<Payment> paymentRepository, 
            IRepository<Vehicle> vehicleRepository, 
            IRepository<Sorting> sortingRepository)
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
            await SeedPackages();
            await SeedSorting();
            await SeedServices();

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
                
                var sortings = await _sortingRepository.GetAsync();
                if (sortings.Count > 0)
                {
                    _sortingRepository.DeleteRange(sortings);
                    await _sortingRepository.SaveChangesAsync();
                    Console.WriteLine("Sortings purged");
                }
                
                var vehicles = await _vehicleRepository.GetAsync();
                if (vehicles.Count > 0)
                {
                    _vehicleRepository.DeleteRange(vehicles);
                    await _vehicleRepository.SaveChangesAsync();
                    Console.WriteLine("Vehicles purged");
                }
                
                var supportIssues = await _supportIssueRepository.GetAsync();
                if (supportIssues.Count > 0)
                {
                    _supportIssueRepository.DeleteRange(supportIssues);
                    await _supportIssueRepository.SaveChangesAsync();
                    Console.WriteLine("SupportIssues purged");
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
                    Type = UserType.Administrator,
                    Address = new Address
                    {
                        Id = 1,
                        City = "Mielec",
                        HouseAndFlatNumber = "13/53",
                        PostalCode = "39-300",
                        Street = "Pisarka"
                    }
                },
                new()
                {
                    Id = 2,
                    FirstName = "Dawid",
                    LastName = "Blaszkiewicz",
                    Email = "dawid@pof.com",
                    Password = "test123",
                    Type = UserType.Administrator,
                    Address = new Address
                    {
                        Id = 2,
                        City = "Czarnocin",
                        HouseAndFlatNumber = "77",
                        PostalCode = "28-506",
                        Street = "Kolosy"
                    }
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
                    Id = 11,
                    City = "Mielec",
                    HouseAndFlatNumber = "12/3",
                    Street = "Osla laka",
                    PostalCode = "30-123"
                },
                new()
                {
                    Id = 12,
                    City = "Kraków",
                    HouseAndFlatNumber = "2",
                    Street = "Myślenicka",
                    PostalCode = "30-144"
                },
                new()
                {
                    Id = 13,
                    City = "Czarnocin",
                    HouseAndFlatNumber = "77",
                    Street = "Kolosy",
                    PostalCode = "28-506"
                }
            };
            
            await _addressRepository.AddRangeAsync(addresses);
            await _addressRepository.SaveChangesAsync();
            Console.WriteLine("Addresses seeded");
        }
        
        private async Task SeedPackages()
        {
            var packages = new List<Package>
            {
                new() {
                    Id = 1,
                    DeliveryDate = DateTime.Now,
                    Status = PackageStatus.Delivered,
                    Width = 12,
                    Height = 12,
                    Length = 12,
                    Weight = 30,
                    DeliveryAddressId = 11,
                    ReceiveAddressId = 12,
                    Payment = new Payment
                    {
                        Status = PaymentStatus.InProgress,
                        Amount = 12.34
                    },
                    Sorting = new Sorting
                    {
                        Name = "Zakliczyn",
                        AddressId = 12,
                    },
                    Service = new Service
                    {
                        Name = "Dostawa dronem",
                        Description = "Dostawa z użyciem drona w ciągu 1h",
                        Price = 100,
                    }
                }
            };

            await _packageRepository.AddRangeAsync(packages);
            await _packageRepository.SaveChangesAsync();
            Console.WriteLine("Packages seeded");
        }

        private async Task SeedServices()
        {
            var services = new List<Service>
            {
                new Service
                {
                    Name = "Standard",
                    Description = "Standardowa dostawa",
                    Price = 10,
                },
                new Service
                {
                    Name = "Express",
                    Description = "Dostawa w 1 dzień roboczy",
                    Price = 15,
                },
                new Service
                {
                    Name = "Weekend",
                    Description = "Dostawa w weekend",
                    Price = 20,
                },
            };

            await _serviceRepository.AddRangeAsync(services);
            await _serviceRepository.SaveChangesAsync();
            Console.WriteLine("Services seeded");
        }

        private async Task SeedSorting()
        {
            var addressSorting1 = new Address
            {
                City = "Kraków",
                HouseAndFlatNumber = "12",
                PostalCode = "22-420",
                Street = "Warszawska"
            };

            var addressSorting2 = new Address
            {
                City = "Katowice",
                HouseAndFlatNumber = "210",
                PostalCode = "12-592",
                Street = "Kolejowa"
            };

            await _addressRepository.AddAsync(addressSorting1);
            await _addressRepository.AddAsync(addressSorting2);
            await _addressRepository.SaveChangesAsync();

            var sortings = new List<Sorting>
            {
                new Sorting
                {
                    Name = "Sortownia Kraków",
                    Address = addressSorting1
                },
                new Sorting
                {
                    Name = "Sortownia Katowice",
                    Address = addressSorting2
                }
            };

            await _sortingRepository.AddRangeAsync(sortings);
            await _sortingRepository.SaveChangesAsync();
            Console.WriteLine("Sorting seeded");
        }
    }
}