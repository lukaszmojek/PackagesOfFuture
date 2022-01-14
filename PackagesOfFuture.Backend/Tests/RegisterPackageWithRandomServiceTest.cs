using Api.Handlers;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Infrastructure.Repositories;
using Data.Entities;
using Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Contracts.Dtos;
using ResourceEnums;

namespace Tests
{
    public class RegisterPackageWithRandomServiceTest
    {
        [Fact]
        public async Task RegisterPackageWithRandomService()
        {

            var connectionString = "User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=PackagesOfFuture2;Pooling=true";

            var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

            var packageRepo = new Repository<Package>(context);

            var addresRepo = new Repository<Address>(context);

            var paymentRepo = new Repository<Payment>(context);

            var serviceRepo = new Repository<Service>(context);

            var sortingRepo = new Repository<Sorting>(context);

            var mapper = new Mock<IMapper>();


            var handler = new RegisterPackageHandler(packageRepo, addresRepo,
                paymentRepo, serviceRepo, sortingRepo, mapper.Object, context);


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

            mapper.Setup(mapper => mapper.Map<Package>(It.IsAny<PackageDetailsDto>())).Returns(new Package
            {
                Height = command.Package.Height,
                Length = command.Package.Length,
                Weight = command.Package.Weight,
                Width = command.Package.Width
            });

            mapper.Setup(mapper => mapper.Map<Address>(It.IsAny<AddressDto>())).Returns(new Address
            {
                City = command.ReceiveAddress.City,
                HouseAndFlatNumber = command.ReceiveAddress.HouseAndFlatNumber,
                PostalCode = command.ReceiveAddress.PostalCode,
                Street = command.ReceiveAddress.Street
            });

            mapper.Setup(mapper => mapper.Map<Payment>(It.IsAny<PaymentDto>())).Returns(new Payment
            {
                Amount = command.Payment.Amount,
                Status = command.Payment.Status,
                Type = command.Payment.Type
            });


            var res = await handler.Handle(command, CancellationToken.None);

            var result = res.ToString();
        }
    }
}