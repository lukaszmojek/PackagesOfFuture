using System.Threading;
using System.Threading.Tasks;
using Api.Commands;
using Api.Handlers;
using Contracts.Dtos;
using Data;
using Data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ResourceEnums;
using Xunit;

namespace Tests;

public class ChangeUserDetailsHandlerTests : HandlerTestBase
{
    [Fact]
    public async Task When_RequestingUserIsAdministrator_Should_ChangeUserDetailsSuccessfully()
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

        optionsBuilder.UseNpgsql(DatabaseConnectionString);

        var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

        var handler = new ChangeUserDetailsHandler(context);

        var address = new AddressDto
        {
            Street = "testStreet",
            HouseAndFlatNumber = "testNumber",
            PostalCode = "testPostalCode",
            City = "testCity"
        };

        var requestingUser = new User
        {
            Id = 2,
            Type = UserType.Administrator
        };
        
        var command = new ChangeUserDetailsCommand
        {
            Id = 9,
            FirstName = "testFirstName",
            LastName = "testLastname",
            Type = UserType.Client,
            Address = address,
            RequestingUser = requestingUser
        };

        var response = await handler.Handle(command, CancellationToken.None);

        response.Succeeded.Should().Be(true);
    }
    
    [Fact]
    public async Task When_RequestingUserIsChagningHisOwnProfile_Should_ChangeUserDetailsSuccessfully()
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

        optionsBuilder.UseNpgsql(DatabaseConnectionString);

        var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

        var handler = new ChangeUserDetailsHandler(context);

        var address = new AddressDto
        {
            Street = "testStreet",
            HouseAndFlatNumber = "testNumber",
            PostalCode = "testPostalCode",
            City = "testCity"
        };

        var requestingUser = new User
        {
            Id = 9,
            Type = UserType.Client
        };
        
        var command = new ChangeUserDetailsCommand
        {
            Id = 9,
            FirstName = "testFirstName",
            LastName = "testLastname",
            Type = UserType.Client,
            Address = address,
            RequestingUser = requestingUser
        };

        var response = await handler.Handle(command, CancellationToken.None);

        response.Succeeded.Should().Be(true);
    }
    
    [Theory]
    [InlineData(UserType.Client)]
    [InlineData(UserType.Driver)]
    public async Task When_RequestingUserIsChagningProfileOfDifferentUserAndHisTypeIsNotAdministrator_Should_FailWithUnauthorizedException(
        UserType requestingUserType)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

        optionsBuilder.UseNpgsql(DatabaseConnectionString);

        var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

        var handler = new ChangeUserDetailsHandler(context);

        var address = new AddressDto
        {
            Street = "testStreet",
            HouseAndFlatNumber = "testNumber",
            PostalCode = "testPostalCode",
            City = "testCity"
        };

        var requestingUser = new User
        {
            Id = 2,
            Type = requestingUserType
        };
        
        var command = new ChangeUserDetailsCommand
        {
            Id = 9,
            FirstName = "testFirstName",
            LastName = "testLastname",
            Type = UserType.Client,
            Address = address,
            RequestingUser = requestingUser
        };

        var response = await handler.Handle(command, CancellationToken.None);

        response.Succeeded.Should().Be(false);
    }
    
    [Theory]
    [InlineData(UserType.Client, UserType.Administrator)]
    [InlineData(UserType.Client, UserType.Driver)]
    [InlineData(UserType.Driver, UserType.Administrator)]
    [InlineData(UserType.Driver, UserType.Client)]
    public async Task When_RequestingUserIsChangingOwnProfileAndTriesToChangeUserTypeNotBeingAndAdministrator_Should_FailWithUnauthorizedException(
        UserType requestingUserType, UserType desiredUserType)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackagesOfFutureDbContext>();

        optionsBuilder.UseNpgsql(DatabaseConnectionString);

        var context = new PackagesOfFutureDbContext(optionsBuilder.Options);

        var handler = new ChangeUserDetailsHandler(context);

        var address = new AddressDto
        {
            Street = "testStreet",
            HouseAndFlatNumber = "testNumber",
            PostalCode = "testPostalCode",
            City = "testCity"
        };

        var requestingUser = new User
        {
            Id = 2,
            Type = requestingUserType
        };
        
        var command = new ChangeUserDetailsCommand
        {
            Id = 9,
            FirstName = "testFirstName",
            LastName = "testLastname",
            Type = desiredUserType,
            Address = address,
            RequestingUser = requestingUser
        };

        var response = await handler.Handle(command, CancellationToken.None);

        response.Succeeded.Should().Be(false);
    }
}