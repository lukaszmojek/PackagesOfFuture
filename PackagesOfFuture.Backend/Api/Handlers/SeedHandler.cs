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
            await SeedSortingWithDrones();
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
                    Type = UserType.Driver,
                    Address = new Address
                    {
                        City = "Podwawelska",
                        HouseAndFlatNumber = "130c",
                        PostalCode = "14-540",
                        Street = "Proszowice"
                    }
                },
                new()
                {
                    Id = 4,
                    FirstName = "Marysia",
                    LastName = "Znajdek",
                    Email = "marysia@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Krzyzowa",
                        HouseAndFlatNumber = "123",
                        PostalCode = "42-135",
                        Street = "Kazimierza Wielka"
                    }

                },
                new()
                {
                    Id = 5,
                    FirstName = "Adam",
                    LastName = "Kiełbasa",
                    Email = "adam@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Woronicza",
                        HouseAndFlatNumber = "32",
                        PostalCode = "55-214",
                        Street = "Kraków"
                    }
                },
                new()
                {
                    Id = 6,
                    FirstName = "Tomasz",
                    LastName = "Długowłosy",
                    Email = "tomasz@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Wiślana",
                        HouseAndFlatNumber = "500",
                        PostalCode = "44-229",
                        Street = "Stalowa Wola"
                    }
                },
                new()
                {
                    Id = 7,
                    FirstName = "Marek",
                    LastName = "Siwizna",
                    Email = "marek@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Skawina",
                        HouseAndFlatNumber = "500",
                        PostalCode = "44-229",
                        Street = "Rusznikarska"
                    }
                },
                new()
                {
                    Id = 8,
                    FirstName = "Jan",
                    LastName = "Paliwo",
                    Email = "jan@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Warszawa",
                        HouseAndFlatNumber = "500",
                        PostalCode = "44-229",
                        Street = "Tęczowa"
                    }
                },
                new()
                {
                    Id = 9,
                    FirstName = "Monika",
                    LastName = "Małecka",
                    Email = "monia123@email.com",
                    Password = "test123",
                    Type = UserType.Client,
                    Address = new Address
                    {
                        City = "Lublin",
                        HouseAndFlatNumber = "3/12",
                        PostalCode = "34-523",
                        Street = "Postępu"
                    }
                },
            };
            
            await _userRepository.AddRangeAsync(users);
            await _userRepository.SaveChangesAsync();
            Console.WriteLine("Users seeded");
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
                new Service
                {
                    Name = "Dostawa dronem",
                    Description = "Dostawa z użyciem drona w ciągu 1h",
                    Price = 100,
                }
            };

            await _serviceRepository.AddRangeAsync(services);
            await _serviceRepository.SaveChangesAsync();
            Console.WriteLine("Services seeded");
        }

        private async Task SeedSortingWithDrones()
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

            var addressSorting3 = new Address
            {
                City = "Warszawa",
                HouseAndFlatNumber = "553",
                PostalCode = "44-200",
                Street = "Potocka"
            };

            await _addressRepository.AddAsync(addressSorting1);
            await _addressRepository.AddAsync(addressSorting2);
            await _addressRepository.SaveChangesAsync();

            var sorting1 = new Sorting
            {
                Name = "Sortownia Kraków",
                Address = addressSorting1
            };

            var sorting2 = new Sorting
            {
                Name = "Sortownia Katowice",
                Address = addressSorting2
            };

            var sorting3 = new Sorting
            {
                Name = "Sortownia Warszawa",
                Address = addressSorting3
            };

            var drones = new List<Drone>
            {
                new Drone
                {
                    Model = "Sony Speed 2",
                    Range = 100,
                    Sorting = sorting1
                },
                new Drone
                {
                    Model = "Xioami Water",
                    Range = 44,
                    Sorting = sorting2
                },
                new Drone
                {
                    Model = "Samsung GT",
                    Range = 50,
                    Sorting = sorting1
                },
                new Drone
                {
                    Model = "Honda 2022",
                    Range = 110,
                    Sorting = sorting2
                },
                new Drone
                {
                    Model = "Logitech G603",
                    Range = 110,
                    Sorting = sorting3
                }
            };

            await _sortingRepository.AddAsync(sorting1);
            await _sortingRepository.AddAsync(sorting2);

            await _droneRepository.AddRangeAsync(drones);

            await _sortingRepository.SaveChangesAsync();
            await _droneRepository.SaveChangesAsync();
            Console.WriteLine("Sorting with drones seeded");
        }
    }
}