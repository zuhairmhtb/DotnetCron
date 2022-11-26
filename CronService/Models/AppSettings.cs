using Microsoft.Extensions.Configuration;

namespace CronService.Models
{
    public static class AppSettings
    {
        public static string ZookeeperTriggerTime = "QuartzSchedule:ZookeeperTriggerTime";
        public static string InvoiceNotificationTriggerTime = "QuartzSchedule:InvoiceNotificationTriggerTime";
        public static string BackOrderNotificationTriggerTime = "QuartzSchedule:BackOrderNotificationTriggerTime";

        public static string GetValue(string key)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            return configuration.GetSection(key).Value;
        }
    }
}
