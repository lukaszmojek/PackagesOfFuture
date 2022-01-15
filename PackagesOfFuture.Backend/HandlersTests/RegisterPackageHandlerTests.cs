using System;
using Api.Handlers;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Infrastructure.Repositories;
using Data.Entities;
using Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Contracts.Dtos;
using ResourceEnums;
using Api.Profiles;

namespace Tests
{
    public class RegisterPackageHandlerTests
    {
        [Fact]
        public async Task SuccessfullyRegisterPackageTest()
        {
            var connectionString = "User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=PackagesOfFuture;Pooling=true";

            var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

            var packageRepo = new Repository<Package>(context);

            var addresRepo = new Repository<Address>(context);

            var paymentRepo = new Repository<Payment>(context);

            var serviceRepo = new Repository<Service>(context);

            var sortingRepo = new Repository<Sorting>(context);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfile>();
                cfg.AddProfile<PackageProfile>();
                cfg.AddProfile<AddressProfile>();
                cfg.AddProfile<PaymentProfile>();

            });

            var mapper = mapperConfig.CreateMapper();

            var handler = new RegisterPackageHandler(packageRepo, addresRepo,
                paymentRepo, serviceRepo, sortingRepo, mapper, context);

            var command = new RegisterPackageCommand
            {
                // adres usera Dawid z seeda 
                DeliveryAddress = new AddressDto
                {
                    City = "Czarnocin",
                    HouseAndFlatNumber = "77",
                    PostalCode = "28-506",
                    Street = "Kolosy"
                },
                ReceiveAddress = new AddressDto
                {
                    City = "Kraków",
                    HouseAndFlatNumber = "130",
                    PostalCode = "22-545",
                    Street = "Kapelana"
                },
                Payment = new PaymentDto
                {
                    Amount = 30,
                    Status = PaymentStatus.InProgress,
                    Type = PaymentType.Check
                },
                Package = new PackageDetailsDto
                {
                    Height = 20,
                    Length = 20,
                    Weight = 5,
                    Width = 20
                },
                ServiceId = 2 //TODO
            };

            var res = await handler.Handle(command, CancellationToken.None);

            var result = res.ToString();

            res.Succeeded.Should().Be(true);
        }

        [Fact]
        public async Task RegisterPackageWithRandomService()
        {

            var connectionString = "User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=PackagesOfFuture;Pooling=true";

            var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

            var packageRepo = new Repository<Package>(context);

            var addresRepo = new Repository<Address>(context);

            var paymentRepo = new Repository<Payment>(context);

            var serviceRepo = new Repository<Service>(context);

            var sortingRepo = new Repository<Sorting>(context);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfile>();
                cfg.AddProfile<PackageProfile>();
                cfg.AddProfile<AddressProfile>();
                cfg.AddProfile<PaymentProfile>();

            });

            var mapper = mapperConfig.CreateMapper();

            var handler = new RegisterPackageHandler(packageRepo, addresRepo,
                paymentRepo, serviceRepo, sortingRepo, mapper, context);


            var command = new RegisterPackageCommand
            {
                // adres usera 2 (Dawid)
                DeliveryAddress = new AddressDto
                {
                    City = "Czarnocin",
                    HouseAndFlatNumber = "77",
                    PostalCode = "28-506",
                    Street = "Kolosy"
                },
                ReceiveAddress = new AddressDto
                {
                    City = "Kraków",
                    HouseAndFlatNumber = "130",
                    PostalCode = "22-545",
                    Street = "Kapelana"
                },
                Payment = new PaymentDto
                {
                    Amount = 30,
                    Status = PaymentStatus.InProgress,
                    Type = PaymentType.Check
                },
                Package = new PackageDetailsDto
                {
                    Height = 20,
                    Length = 20,
                    Weight = 5,
                    Width = 20
                },
                ServiceId = 100
            };

            await Assert.ThrowsAsync<ArgumentException>(async ()
                => await handler.Handle(command, CancellationToken.None));
        }
    }
}