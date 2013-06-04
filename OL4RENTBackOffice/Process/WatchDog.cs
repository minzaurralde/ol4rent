using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace OL4RENTBackOffice.Process
{
    public class WatchDog : IJob
    {
        public WatchDog()
        {
        }

        public void Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("WatchDog is executing." + DateTimeOffset.Now);
        }

        public static void IniciarWatchDog()
        {
            try
            {
                // Iniciar un Scheduler
                var sf = new StdSchedulerFactory();
                var sched = sf.GetScheduler();
                sched.Start();

                // Creo el Job
                var jobDetail = new JobDetailImpl("WatchDog", null, typeof(WatchDog));

                // Creo el Trigger
                var trigger = new SimpleTriggerImpl("WatchDogTrigger", SimpleTriggerImpl.RepeatIndefinitely, new TimeSpan(0, 1, 0));
                trigger.StartTimeUtc = DateTimeOffset.Now;

                // Agrego el Job al Scheduler
                sched.ScheduleJob(jobDetail, trigger);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al iniciar el WatchDog: " + e);
            }
        }
    }
}
