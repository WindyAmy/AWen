using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Common;
using AWen.TaskManager.Core.Model;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

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
        // private readonly ILog _logger = LogManager.GetLogger(typeof(TaskServicesRunner));
        //任务调度器
        private readonly IScheduler scheduler;

        private readonly TB_TM_TaskInfo majorTaskInfo;

        #region 构造函数

        public TaskServicesRunner()
        {
            //获取默认任务调度器

            scheduler = StdSchedulerFactory.GetDefaultScheduler();

            majorTaskInfo = new TB_TM_TaskInfo()
            {
                TaskId = -1,
                TaskType = TaskType.IJob.ToString(),
                TaskName = System.Configuration.ConfigurationManager.AppSettings["MajorTaskName"],
                Description = System.Configuration.ConfigurationManager.AppSettings["MajorTaskDescription"],
                CronExpression = System.Configuration.ConfigurationManager.AppSettings["MajorTaskCronExpression"],
                CronExpressionDescription = System.Configuration.ConfigurationManager.AppSettings["MajorTaskCronExpressionDescription"], 
            };
            //scheduler.ListenerManager.AddSchedulerListener(new SchedulerListener());
            scheduler.ListenerManager.AddJobListener(new SchedulerJobListener(), GroupMatcher<JobKey>.GroupStartsWith("TaskGroup."));
            var job = JobBuilder.Create<MajorTask>()
                .WithIdentity(majorTaskInfo.TaskName + ".TaskName", majorTaskInfo.TaskName + ".TaskGroup")
                .Build();
            job.JobDataMap.Add("TaskInfo", JsonConvert.SerializeObject(majorTaskInfo));
            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithIdentity(majorTaskInfo.TaskName + ".TriggerName", majorTaskInfo.TaskName + ".TriggerGroup")
                .WithCronSchedule(majorTaskInfo.CronExpression)
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        #endregion 构造函数

        #region 接口实现

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            WriteTaskLog("调度器启动--Start");
            // _logger.Info(string.Format("{0} Start---------------------------", ServiceName));
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown();
            WriteTaskLog("调度器关闭--Shutdown");
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            if (scheduler.IsShutdown)
            {
                scheduler.Start();
                WriteTaskLog("调度器重新启动--Continue");
            }

            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            if (scheduler.IsStarted)
            {
                scheduler.PauseAll();
                WriteTaskLog("调度器暂停--PauseAll");
            }
            return true;
        }

        #endregion 接口实现

        private string ServiceName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName");
            }
        }

        #region WriteTaskLog

        private void WriteTaskLog(string runLog)
        {
            new TaskLogService().Add(new TaskManager.Core.Model.TB_TM_TaskLog()
            {
                TaskId = majorTaskInfo.TaskId,
                TaskName = majorTaskInfo.TaskName,
                ExecutionDuration = 0,
                CreatedDateTime = DateTime.Now,
                ExecutionTime = DateTime.Now,
                RunLog = runLog
            });
        }

        #endregion WriteTaskLog
    }
}