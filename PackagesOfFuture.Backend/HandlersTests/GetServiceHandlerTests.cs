using Api.Handlers;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Infrastructure.Repositories;
using Data.Entities;
using System.Threading;
using System.Threading.Tasks;
using Api.Queries;
using FluentAssertions;
using Api.Profiles;

namespace Tests
{
    public class GetServiceHandlerTests
    {
        [Fact]
        public async Task GetServiceTest()
        {

            var connectionString = "User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=PackagesOfFuture;Pooling=true";

            var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

            var serviceRepo = new Repository<Service>(context);

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<ServiceProfile>());

            var mapper = mapperConfig.CreateMapper();

            var getServiceHandler = new GetServicesHandler(serviceRepo, mapper);

            var query = new GetServicesQuery
            {

            };

            var res = await getServiceHandler.Handle(query, CancellationToken.None);

            res.Count.Should().Be(4);
        }
    }
}