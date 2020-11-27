using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Extensions;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.Entities;

namespace Logic
{
    public static class Startup
    {
        private static DbContext dbContext;
        private static ClientManager clientManager;

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<DbContext, PackagesOfFutureDbContext>()
                .RegisterRepositories()
                .AddScoped<UnitOfWork>();

            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);

            return serviceProvider;
        }

        public static async Task Run()
        {
            dbContext = new PackagesOfFutureDbContext();
            var repo = new Repository<Client>(dbContext);
            clientManager = new ClientManager(repo);

            var dawidExists = await clientManager.ClientExistsAsync(2).ConfigureAwait(false);
            if (dawidExists)
            {
                var dawidDetails = await repo.GetById(2).ConfigureAwait(false);
                Console.WriteLine(dawidDetails.UserName);
            }
            ;
        }
    }
}

namespace Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Client>, Repository<Client>>();
            services.AddScoped<IRepository<Address>, Repository<Address>>();

            return services;
        }
    }
}
