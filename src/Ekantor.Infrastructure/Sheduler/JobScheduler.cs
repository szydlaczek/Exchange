using Quartz;

namespace Exchange.Infrastructure.Sheduler
{
    public class JobScheduler
    {
        private readonly IScheduler _scheduler;

        public JobScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Start()
        {
            _scheduler.Start();

            IJobDetail job = JobBuilder.Create<DownloadCurrenciesJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x
                    .RepeatForever()
                    .WithIntervalInSeconds(20)
                 )
                .StartNow()
                .Build();

            _scheduler.ScheduleJob(job, trigger);
        }
    }
}