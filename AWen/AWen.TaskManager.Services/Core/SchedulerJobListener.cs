/********************************************************************
 * 命名空间: AWen.TaskManager.Services.Core

 * 文件名称: SchedulerJobListener

 * 文件作者: AWen

 * 创建时间: 2018/4/16 14:28:03
=====================================================================
 * 功能说明: Quartz的监听器
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Model;
using Newtonsoft.Json;
using Quartz;
using System;

namespace AWen.TaskManager.Services.Core
{
    public class SchedulerJobListener : IJobListener
    {
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            DateTime NextFireTimeUtc = TimeZoneInfo.ConvertTimeFromUtc(context.NextFireTimeUtc.Value.DateTime, TimeZoneInfo.Local);
            DateTime FireTimeUtc = TimeZoneInfo.ConvertTimeFromUtc(context.FireTimeUtc.Value.DateTime, TimeZoneInfo.Local);

            double TotalSeconds = context.JobRunTime.TotalSeconds;

            TB_TM_TaskInfo taskInfo = null;
            string LogContent = string.Empty;
            if (context.MergedJobDataMap != null)
            {

                if (context.MergedJobDataMap.ContainsKey("TaskInfo"))
                   taskInfo = JsonConvert.DeserializeObject<TB_TM_TaskInfo>(context.MergedJobDataMap.GetString("TaskInfo"));

                if(taskInfo!=null)
                {
                    System.Text.StringBuilder log = new System.Text.StringBuilder();
                    int i = 0;
                    foreach (var item in context.MergedJobDataMap)
                    {
                        string key = item.Key;
                        if (key.StartsWith("Extend_"))
                        {
                            if (i > 0)
                            {
                                log.Append(",");
                            }
                            log.AppendFormat("{0}:{1}", item.Key, item.Value);
                            i++;
                        }
                    }
                    if (i > 0)
                    {
                        LogContent = string.Concat("[", log.ToString(), "]");
                    }
                    TaskInfoService _TaskInfoService = new TaskInfoService();
                    TaskLogService _TaskLogService = new TaskLogService();
                    taskInfo = _TaskInfoService.GetModel(taskInfo.TaskId);
                    taskInfo.LastRunTime = FireTimeUtc;
                    taskInfo.NextRunTime = NextFireTimeUtc;
                    taskInfo.RunCount = taskInfo.RunCount + 1;
                    _TaskInfoService.Update(taskInfo);
                    _TaskLogService.Add(new TaskManager.Core.Model.TB_TM_TaskLog()
                    {
                        TaskId = taskInfo.TaskId,
                        TaskName = taskInfo.TaskName,
                        CreatedDateTime = DateTime.Now,
                        ExecutionTime = FireTimeUtc,
                        ExecutionDuration = TotalSeconds,
                        RunLog = LogContent
                    });
                }
               
            }
            //if (jobException != null)
            //{
            //    LogContent = LogContent + " EX:" + jobException.ToString();
            //    new TaskLogService().Add(new TaskManager.Core.Model.TB_TM_TaskLog()
            //    {
            //        TaskId = Convert.ToInt32(TaskId),
            //        TaskName = TaskName,
            //        CreatedDateTime = DateTime.Now,
            //        ExecutionTime = FireTimeUtc,
            //        ExecutionDuration = TotalSeconds,
            //        RunLog = LogContent
            //    });
            //}
        }

        public string Name
        {
            get { return "SchedulerJobListener"; }
        }
    }
}