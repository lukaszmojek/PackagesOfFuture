using System;
using Logic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Infrastructure.Tests
{
    public class StartupTests
    {
        [Fact]
        public void Throws_exception_if_ConfigureServices_is_not_called_before_getting_ServiceProviderInstance()
        {
            Assert.Throws<NullReferenceException>(() => Startup.GetServiceProviderInstance());
        }

        [Fact]
        public void Retrieves_ServiceProvider_successfully()
        {
            Startup.ConfigureServices();

            var serviceProvider = Startup.GetServiceProviderInstance();

            Assert.NotNull(serviceProvider);
        }

        [Fact]
        public void ServiceProvider_can_retrieve_UnitOfWork()
        {
            Startup.ConfigureServices();
            var serviceProvider = Startup.GetServiceProviderInstance();

            var unitOfWork = serviceProvider.GetService<UnitOfWork>();

            Assert.NotNull(unitOfWork);
        }
    }
}
