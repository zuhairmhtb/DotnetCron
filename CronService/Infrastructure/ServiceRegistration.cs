using CronService.Services.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace CronService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ZookeeperJob>();
            services.AddSingleton<InvoiceNotificationJob>();
            services.AddSingleton<BackOrderNotificationJob>();
        }
    }
}
