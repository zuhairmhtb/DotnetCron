# Cron Application using Quartz

The main application contains two types of Jobs:

1. Zookeeper: This is the master scheduler which periodically checks the appsettings to see if any of the cron trigger schedule has been updated for any of the worker. If any worker's cron schedule gets updated, it reschedules the worker's job.

2. Worker: These are worker jobs that can perform certain tasks. The trigger time of these workers are controlled by the zooperkeeper and the trigger time can be updated without restarting the application.


# Testing Cron Schedule

1. Run the application (Requires support for .Net Core 3.1).

2. Currently, two worker jobs are available - Invoice and BackOrder. They just print console outputs for now.

3. When the application is running you can see the console to check which worker is executing at which time.

4. While the application is running in debug mode, navigate to CronService/CronService/bin/Debug/netcoreapp3.1 and open the file appsettings.json.

5. Update the cron schedule time in the appsettings and you will see that the schedule of the worker changes automatically without requiring a restart of the application.

6. Currently, the cron trigger schedules are collected from appsettings. But you can modify the code to fetch the schedule time from database as well.

**You can view the complete article at [Medium](https://medium.com/@zuhairmhtb/cron-scheduler-with-net-core-and-quartz-d2361aa2bf1b).**
