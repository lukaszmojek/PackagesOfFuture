using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Console
{
    public static class Program
    {
        // Here you can test created logic
        public static async Task Main(string[] args)
        {
            Startup.ConfigureServices();
            var serviceProvider = Startup.GetServiceProviderInstance();
            // Code above is mandatory, without it application won't work

            var unitOfWork = serviceProvider.GetService<UnitOfWork>();
            
            var dawid = await unitOfWork.ClientRepository.GetById(2);
            ;
        }
    }
}
