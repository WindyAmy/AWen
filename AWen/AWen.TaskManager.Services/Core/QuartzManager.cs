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
using Quartz;
using System;
using System.IO;
using System.Reflection;
using System.Web;

namespace AWen.TaskManager.Services.Core
{
    public class QuartzManager
    {
        /// <summary>
        ///  任务管理
        /// </summary>
        /// <param name="scheduler"></param>
        public void TaskManager(IScheduler scheduler)
        {
            TaskInfoService _TaskInfoService = new TaskInfoService();
            TaskLogService _TaskLogService = new TaskLogService();
            var taskList = _TaskInfoService.GetModelList(null, null);
            if (taskList != null)
            {
                foreach (var taskModel in taskList)
                {
                    JobKey jobKey = new JobKey(taskModel.TaskId + "Name", taskModel.TaskId + "Group");
                    if (scheduler.CheckExists(jobKey).Result)//任务存在
                    {
                        //即将停止,删除任务并变成停止状态
                        if (taskModel.State == (int)TaskState.Stopping)
                        {
                            bool deleteFlag = scheduler.DeleteJob(jobKey).Result;
                            if (deleteFlag)
                            {
                                taskModel.State = (int)TaskState.Stopped;
                                _TaskInfoService.Update(taskModel);
                                _TaskLogService.Add(new TaskManager.Core.Model.TB_TM_TaskLog()
                                {
                                    TaskId = taskModel.TaskId,
                                    TaskName = taskModel.TaskName,
                                    CreatedDateTime = DateTime.Now,
                                    ExecutionTime = DateTime.Now,
                                    RunLog = "该任务已经停止运行"
                                });
                            }
                        }
                        //即将启动，变成开启状态
                        else if (taskModel.State == (int)TaskState.Starting)
                        {
                            taskModel.State = (int)TaskState.Running;
                            _TaskInfoService.Update(taskModel);
                            _TaskLogService.Add(new TaskManager.Core.Model.TB_TM_TaskLog()
                            {
                                TaskId = taskModel.TaskId,
                                TaskName = taskModel.TaskName,
                                CreatedDateTime = DateTime.Now,
                                ExecutionTime = DateTime.Now,
                                RunLog = "该任务已经启动运行"
                            });
                        }
                    }
                    else
                    {
                        if (taskModel.State == (int)TaskState.Starting
                            || taskModel.State == (int)TaskState.Running
                            )
                        {
                            //添加job
                            ScheduleJob(scheduler, taskModel);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Job调度
        /// </summary>
        /// <param name="scheduler"></param>
        /// <param name="taskInfo"></param>
        public void ScheduleJob(IScheduler scheduler, TB_TM_TaskInfo taskInfo)
        {
            if (ValidExpression(taskInfo.CronExpression))
            {
                Type type = GetClassInfo(taskInfo.AssemblyName, taskInfo.ClassName);
                if (type != null)
                {
                    var job = JobBuilder.Create(type)
                                        .WithIdentity(taskInfo.TaskId + "TaskName", taskInfo.TaskId + "TaskGroup")
                        //.WithDescription(taskInfo.Description)//任务描述
                                        .Build();
                    job.JobDataMap.Add("Parameters", taskInfo.TaskArgs);
                    job.JobDataMap.Add("TaskName", taskInfo.TaskName);
                    job.JobDataMap.Add("TaskType", taskInfo.TaskType);
                    var trigger = TriggerBuilder.Create()
                        .WithIdentity(taskInfo.TaskId + "TriggerName", taskInfo.TaskId + "TriggerGroup")
                        //.WithDescription(taskInfo.Description)//任务描述
                        .StartNow()
                        .WithCronSchedule(taskInfo.CronExpression)
                        .Build();
                    scheduler.ScheduleJob(job, trigger);
                }
                else
                {
                    new TaskLogService().Add(new TaskManager.Core.Model.TB_TM_TaskLog()
                                {
                                    TaskId = taskInfo.TaskId,
                                    TaskName = taskInfo.TaskName,
                                    CreatedDateTime = DateTime.Now,
                                    ExecutionTime = DateTime.Now,
                                    RunLog = taskInfo.AssemblyName + taskInfo.ClassName + "无效，无法启动该任务"
                                });
                    taskInfo.State = (int)TaskState.Error;
                    new TaskInfoService().Update(taskInfo);
                }
            }
            else
            {
                new TaskLogService().Add(new TaskManager.Core.Model.TB_TM_TaskLog()
                                 {
                                     TaskId = taskInfo.TaskId,
                                     TaskName = taskInfo.TaskName,
                                     CreatedDateTime = DateTime.Now,
                                     ExecutionTime = DateTime.Now,
                                     RunLog = taskInfo.CronExpression + "不是正确的Cron表达式,无法启动该任务"
                                 });
                taskInfo.State = (int)TaskState.Error;
                new TaskInfoService().Update(taskInfo);
            }
        }

        /// <summary>
        /// 从程序集中加载指定类
        /// </summary>
        /// <param name="assemblyName">含后缀的程序集名</param>
        /// <param name="className">含命名空间完整类名</param>
        /// <returns></returns>
        private Type GetClassInfo(string assemblyName, string className)
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

        /// <summary>
        ///  获取文件的绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns></returns>
        public string GetAbsolutePath(string relativePath)
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

        /// <summary>
        /// 校验字符串是否为正确的Cron表达式
        /// </summary>
        /// <param name="cronExpression">带校验表达式</param>
        /// <returns></returns>
        public bool ValidExpression(string cronExpression)
        {
            return CronExpression.IsValidExpression(cronExpression);
        }
    }
}