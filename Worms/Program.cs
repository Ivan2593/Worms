using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Worms.Hosts;
using Worms.Logics;

namespace Worms
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(null).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<WorldSimulatorService>();
                    services.AddScoped<FoodHost>();
                    services.AddScoped<WormsHost>();
                    services.AddScoped<LogHost>();
                    services.AddScoped<NameHost>();
                    services.AddScoped<WorldLogic>();
                });

        }
    }
}