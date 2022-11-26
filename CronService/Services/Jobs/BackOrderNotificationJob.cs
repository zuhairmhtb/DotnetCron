using CronService.Models;
using Quartz;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CronService.Services.Jobs
{
    class BackOrderNotificationJob : WorkerJob
    {
        public static string JobName = "BackOrderNotificationJob";
        public static string JobGroup = "BackOrderNotificationJobGroup";
        public static string TriggerName = "BackOrderNotificationTrigger";
        public static string TriggerGroup = "BackOrderNotificationTriggerGroup";

        public BackOrderNotificationJob() : base(
            JobName, JobGroup, TriggerName, TriggerGroup,
            AppSettings.BackOrderNotificationTriggerTime, typeof(BackOrderNotificationJob)
            )
        {

        }

        public override IJob GetJob(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<BackOrderNotificationJob>();
        }
        public override Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("Running BackOrder Notification Job at " + DateTime.Now.ToString());
                var triggerTime = AppSettings.GetValue(AppSettings.BackOrderNotificationTriggerTime);
                //Console.WriteLine($"Current Invoice Notification trigger time: {triggerTime}");
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine("Received an error when executing BackOrder Notification job. " + e.Message);
                return Task.FromException(e);
            }
        }
    }
}
