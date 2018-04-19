using AWen.TaskManager.Core.Common;
using AWen.TaskManager.Core.Model;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;

/********************************************************************
 * 命名空间: AWen.TaskManager.Services.Core

 * 文件名称: ProxyTask

 * 文件作者: AWen

 * 创建时间: 2018/4/16 11:32:16
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

namespace AWen.TaskManager.Services.Core
{
    public class ProxyTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var jobDataMap = context.JobDetail.JobDataMap;
            TB_TM_TaskInfo taskInfo = null;
            if (jobDataMap != null)
            {
                if (jobDataMap.ContainsKey("TaskInfo"))
                    taskInfo = JsonConvert.DeserializeObject<TB_TM_TaskInfo>(jobDataMap.GetString("TaskInfo"));

                if (taskInfo != null)
                {
                    if (taskInfo.TaskType == TaskType.Exe.ToString())
                    {
                        #region Exe Job

                        try
                        {
                            //参数设置
                            string arguments = string.Empty;
                            if (!string.IsNullOrEmpty(taskInfo.TaskArgs))
                            {
                                var tmpDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(taskInfo.TaskArgs);
                                arguments = string.Join(" ", tmpDic.Values);//空格分隔
                            }

                            System.Diagnostics.Process exep = new System.Diagnostics.Process();
                            exep.StartInfo.ErrorDialog = false;//错误窗口不显示
                            exep.StartInfo.UseShellExecute = false;
                            exep.StartInfo.RedirectStandardOutput = true;
                            exep.StartInfo.RedirectStandardError = true;  // 重定向错误输出
                            exep.StartInfo.FileName = QuartzManager.GetAbsolutePath(taskInfo.AssemblyName);//exe 文件地址
                            exep.StartInfo.CreateNoWindow = true;
                            exep.StartInfo.Arguments = arguments;//参数以空格分隔，如果某个参数为空，可以传入””
                            exep.Start();
                            exep.WaitForExit();//关键，等待外部程序退出后才能往下执行
                            string output = exep.StandardOutput.ReadToEnd();
                            context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Return", output);
                            //错误
                            string error = exep.StandardError.ReadToEnd();
                            if (!string.IsNullOrEmpty(error))
                            {
                                context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Error", error);
                            }
                        }
                        catch (Exception ex)
                        {
                            context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Exception", ex.Message);
                        }

                        #endregion Exe Job
                    }
                    else if (taskInfo.TaskType == TaskType.Url.ToString())
                    {
                        #region Url Job

                        try
                        {
                            //参数设置
                            Dictionary<string, string> argsDic = new Dictionary<string, string>();
                            if (!string.IsNullOrEmpty(taskInfo.TaskArgs) && taskInfo.TaskArgs.Contains(","))
                            {
                                argsDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(taskInfo.TaskArgs);
                            }

                            var Response = HttpHelper.CreatePostHttpResponse(taskInfo.AssemblyName, argsDic);

                            if (Response != null)
                            {
                                context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Return", "Code:" + Response.StatusCode + "--Description:" + Response.StatusDescription);

                                //错误
                                if (Response.StatusCode != System.Net.HttpStatusCode.OK)
                                {
                                    context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Error", HttpHelper.GetResponseString(Response));
                                }
                            }
                            else
                            {
                                throw new Exception("Response返回null");
                            }
                        }
                        catch (Exception ex)
                        {
                            context.MergedJobDataMap.Add("Extend_" + taskInfo.TaskType + "_Exception", ex.Message);
                        }

                        #endregion Url Job
                    }
                }
            }
        }
    }
}