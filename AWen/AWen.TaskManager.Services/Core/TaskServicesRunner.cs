using Quartz;
using Quartz.Impl;

/********************************************************************
 * 命名空间: AWen.TaskManager.Services.Core

 * 文件名称: TaskServicesRunner

 * 文件作者: AWen

 * 创建时间: 2018/4/12 16:37:07
=====================================================================
 * 功能说明:主要是使用这个类来实现服务的运行
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;
using Topshelf;

namespace AWen.TaskManager.Services.Core
{
    public class TaskServicesRunner : ServiceControl, ServiceSuspend
    {
        //任务调度器
        public IScheduler scheduler;

        public TaskServicesRunner()
        {
            //获取默认任务调度器
            scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            var job = JobBuilder.Create<MajorTask>()
                .WithIdentity("AWen.MajorTaskName", "AWen.MajorTaskGroup")
                .Build();
            var trigger = TriggerBuilder.Create().StartNow().WithSimpleSchedule(a =>
            {
                a.WithIntervalInSeconds(10);
                a.RepeatForever();
            }).Build();

            scheduler.ScheduleJob(job, trigger);
        }

        public bool Start(HostControl hostControl)
        {
            //Console.WriteLine("Start");
            scheduler.Start();
            return true;
            //throw new NotImplementedException();
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("Stop");
            return true;
            //throw new NotImplementedException();
        }

        public bool Continue(HostControl hostControl)
        {
            throw new NotImplementedException();
        }

        public bool Pause(HostControl hostControl)
        {
            throw new NotImplementedException();
        }
    }
}