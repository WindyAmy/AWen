/********************************************************************
 * 命名空间: AWen.TaskManager.Services.Core

 * 文件名称: QuartzManager

 * 文件作者: AWen

 * 创建时间: 2018/4/16 8:39:56
=====================================================================
 * 功能说明: Quartz的管理类负责任务调度
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Common;
using AWen.TaskManager.Core.Model;
using Newtonsoft.Json;
using Quartz;
using System;
using System.IO;
using System.Reflection;
using System.Web;

namespace AWen.TaskManager.Services.Core
{
    public class QuartzManager
    {
        #region 任务主管理

        /// <summary>
        ///  任务管理
        /// </summary>
        /// <param name="scheduler"></param>
        public  void TaskManager(IScheduler scheduler)
        {
            var taskList = new TaskInfoService().GetModelList("WHERE IsDelete=0", null);
            if (taskList != null)
            {
                foreach (var taskInfo in taskList)
                {
                    JobKey jobKey = new JobKey("TaskName." + taskInfo.TaskId, "TaskGroup." + taskInfo.TaskId);
                    if (scheduler.CheckExists(jobKey))//任务存在
                    {
                        //即将停止,删除任务并变成停止状态
                        if (taskInfo.State == (int)TaskState.Stopping || taskInfo.State == (int)TaskState.Stopped)
                        {
                            bool deleteFlag = scheduler.DeleteJob(jobKey);
                            if (deleteFlag)
                            {
                                WriteTaskLog(taskInfo, "该任务已经停止运行并删除", TaskState.Stopped);
                            }
                        }
                        //即将启动，变成开启状态
                        else if (taskInfo.State == (int)TaskState.Starting)
                        {
                            WriteTaskLog(taskInfo, "该任务已经从Starting-->Running", TaskState.Running);
                        }
                    }
                    else
                    {
                        if (taskInfo.State == (int)TaskState.Starting || taskInfo.State == (int)TaskState.Running)
                        {
                            //添加job
                            if (AddScheduleJob(scheduler, taskInfo))
                            {
                                WriteTaskLog(taskInfo, "该任务已经添加计划并启动运行", TaskState.Running);
                            }
                        }
                    }
                }
            }
        }

        #endregion 任务主管理

        #region 添加任务

        /// <summary>
        /// Job调度
        /// </summary>
        /// <param name="scheduler"></param>
        /// <param name="taskInfo"></param>
        public  bool AddScheduleJob(IScheduler scheduler, TB_TM_TaskInfo taskInfo)
        {
            bool addFlag = false;
            if (ValidExpression(taskInfo.CronExpression))
            {
                Type type = null;
                if (taskInfo.TaskType == TaskType.IJob.ToString())
                {
                    type = GetClassInfo(taskInfo.AssemblyName, taskInfo.ClassName);
                }
                else if (taskInfo.TaskType == TaskType.Exe.ToString() || taskInfo.TaskType == TaskType.Url.ToString())
                {
                    type = typeof(ProxyTask);
                }
                else
                {
                    WriteTaskLog(taskInfo, "TaskType:[" + taskInfo.TaskType + "]不正确,无法启动该任务", TaskState.Error);
                }
                if (type != null)
                {
                    try
                    {
                        var job = JobBuilder.Create(type)
                                            .WithIdentity("TaskName." + taskInfo.TaskId, "TaskGroup." + taskInfo.TaskId)
                            .WithDescription(taskInfo.Description)//任务描述
                                            .Build();
                        job.JobDataMap.Add("TaskInfo", JsonConvert.SerializeObject(taskInfo));
                        var trigger = TriggerBuilder.Create()
                            .WithIdentity("TriggerName." + taskInfo.TaskId, "TriggerGroup." + taskInfo.TaskId)
                            .WithDescription(taskInfo.Description)//任务描述
                            //.StartNow()
                            .WithCronSchedule(taskInfo.CronExpression)
                            .Build();
                        scheduler.ScheduleJob(job, trigger);
                        addFlag = true;
                    }
                    catch (Exception ex)
                    {
                        WriteTaskLog(taskInfo, "创建任务异常:[" + ex.Message + "],无法启动该任务", TaskState.Error);
                    }
                }
                else
                {
                    WriteTaskLog(taskInfo, "AssemblyName:[" + taskInfo.AssemblyName + ",ClassName:" + taskInfo.ClassName + "]无效,无法启动该任务", TaskState.Error);
                }
            }
            else
            {
                WriteTaskLog(taskInfo, "CronExpression:[" + taskInfo.CronExpression + "]不正确,无法启动该任务", TaskState.Error);
            }
            return addFlag;
        }

        #endregion 添加任务

        #region 任务失败写log表,并调整任务状态

        /// <summary>
        /// 任务失败写log表,并调整任务状态是Error
        /// </summary>
        /// <param name="taskInfo"></param>
        /// <param name="runLog"></param>
        private  void WriteTaskLog(TB_TM_TaskInfo taskInfo, string runLog, TaskState taskState)
        {
            new TaskLogService().Add(new TaskManager.Core.Model.TB_TM_TaskLog()
            {
                TaskId = taskInfo.TaskId,
                TaskName = taskInfo.TaskName,
                ExecutionDuration=0,
                CreatedDateTime = DateTime.Now,
                ExecutionTime = DateTime.Now,
                RunLog = runLog
            });
            taskInfo.State = (int)taskState;
            new TaskInfoService().Update(taskInfo);
        }

        #endregion 任务失败写log表,并调整任务状态

        #region 从程序集中加载指定类

        /// <summary>
        /// 从程序集中加载指定类
        /// </summary>
        /// <param name="assemblyName">含后缀的程序集名</param>
        /// <param name="className">含命名空间完整类名</param>
        /// <returns></returns>
        private  Type GetClassInfo(string assemblyName, string className)
        {
            Type type = null;
            try
            {
                assemblyName = GetAbsolutePath(assemblyName);
                Assembly assembly = null;
                assembly = Assembly.LoadFrom(assemblyName);
                type = assembly.GetType(className, true, true);
            }
            catch (Exception ex)
            {
            }
            return type;
        }

        #endregion 从程序集中加载指定类

        #region 获取文件的绝对路径

        /// <summary>
        ///  获取文件的绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns></returns>
        public  string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException("参数relativePath空异常！");
            }
            relativePath = relativePath.Replace("/", "\\");
            if (relativePath[0] == '\\')
            {
                relativePath = relativePath.Remove(0, 1);
            }
            if (HttpContext.Current != null)
            {
                return Path.Combine(HttpRuntime.AppDomainAppPath, relativePath);
            }
            else
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            }
        }

        #endregion 获取文件的绝对路径

        #region 校验字符串是否为正确的Cron表达式

        /// <summary>
        /// 校验字符串是否为正确的Cron表达式
        /// </summary>
        /// <param name="cronExpression">带校验表达式</param>
        /// <returns></returns>
        public  bool ValidExpression(string cronExpression)
        {
            return CronExpression.IsValidExpression(cronExpression);
        }

        #endregion 校验字符串是否为正确的Cron表达式
    }
}