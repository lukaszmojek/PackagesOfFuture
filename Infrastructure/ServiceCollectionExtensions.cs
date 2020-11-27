using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Entities;

namespace Logic
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Client>, Repository<Client>>();
            services.AddScoped<IRepository<Address>, Repository<Address>>();

            return services;
        }
    }
}