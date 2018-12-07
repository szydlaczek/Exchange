using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Exchange.Web.Quartz
{
    public class JobClass : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json; charset=utf-8");
                client.Headers.Add("Accept:application/json");
                var json = client.DownloadString("http://webtask.future-processing.com:8068/currencies");
            }
            return Task.CompletedTask;
        }
    }
    public class JobScheduler
    {
        public static void Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            IScheduler scheduler = schedFact.GetScheduler().Result;
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<JobClass>().Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10)
            .RepeatForever())
            .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}