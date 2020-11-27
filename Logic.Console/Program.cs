using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using Extensions;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.Entities;

namespace Logic.Console
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build();

            var serviceProvider = Startup.ConfigureServices();

            var unitOfWork = serviceProvider.GetService<UnitOfWork>();
            
            var dawid = await unitOfWork.ClientRepository.GetById(2);
            //var repository = services.FirstOrDefault(x => x.GetType().Equals(typeof(Repository<Client>)));
            //await Startup.Run();

        }
    }


}


