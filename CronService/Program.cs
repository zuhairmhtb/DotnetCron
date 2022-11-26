using CronService.Infrastructure;
using CronService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CronService
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost Host = CreateHostBuilder(args).Build();
            Host.Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices(async services => {
                    services.AddOptions();
                    ServiceRegistration.AddServices(services);
                    await SchedulerConfiguration.Configure(services);
                });
        }
    }
}
