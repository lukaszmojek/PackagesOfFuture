using Data.Entities;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Address>, Repository<Address>>();
            services.AddScoped<IRepository<Package>, Repository<Package>>();
            services.AddScoped<IRepository<Sorting>, Repository<Sorting>>();
            services.AddScoped<IRepository<Drone>, Repository<Drone>>();
            services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>();
            services.AddScoped<IRepository<Service>, Repository<Service>>();
            services.AddScoped<IRepository<Payment>, Repository<Payment>>();
            services.AddScoped<IRepository<SupportIssue>, Repository<SupportIssue>>();

            return services;
        }
    }
}