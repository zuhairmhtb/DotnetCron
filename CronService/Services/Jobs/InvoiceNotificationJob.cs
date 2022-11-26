using CronService.Models;
using Quartz;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CronService.Services.Jobs
{
    /// <summary>
    /// This class simulates generating invoice notification. This is a job which is managd by the zookeeper
    /// </summary>
    public class InvoiceNotificationJob : WorkerJob
    {
        public static string JobName = "InvoiceNotificationJob";
        public static string JobGroup = "InvoiceNotificationJobGroup";
        public static string TriggerName = "InvoiceNotificationTrigger";
        public static string TriggerGroup = "InvoiceNotificationTriggerGroup";

        public InvoiceNotificationJob() : base(
            JobName, JobGroup, TriggerName, TriggerGroup, 
            AppSettings.InvoiceNotificationTriggerTime, typeof(InvoiceNotificationJob)
            )
        {

        }

        public override IJob GetJob(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<InvoiceNotificationJob>();
        }
        public override Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("Running Invoice Notification Job at " + DateTime.Now.ToString());
                var triggerTime = AppSettings.GetValue(AppSettings.InvoiceNotificationTriggerTime);
                //Console.WriteLine($"Current Invoice Notification trigger time: {triggerTime}");
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine("Received an error when executing Invoice Notification job. " + e.Message);
                return Task.FromException(e);
            }
        }
    }
}
