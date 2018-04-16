using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Common;
using Quartz;
using System;

/********************************************************************
 * 命名空间: AWen.TaskManager.Services.Core

 * 文件名称: MajorTask

 * 文件作者: AWen

 * 创建时间: 2018/4/13 16:30:38
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System.Threading.Tasks;

namespace AWen.TaskManager.Services.Core
{
    public class MajorTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            IScheduler _Scheduler = context.Scheduler;
            new QuartzManager().TaskManager(_Scheduler);
            return null;
        }

        
    }
}