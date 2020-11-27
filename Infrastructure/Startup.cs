using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;

namespace Logic
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<DbContext, PackagesOfFutureDbContext>()
                .RegisterRepositories()
                .AddScoped<UnitOfWork>();

            var serviceProviderFactory = new DefaultServiceProviderFactory();
            
            serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
        }

        public static IServiceProvider GetServiceProviderInstance()
        {
            return serviceProvider ?? throw new NullReferenceException(nameof(serviceProvider));
        }
    }
}