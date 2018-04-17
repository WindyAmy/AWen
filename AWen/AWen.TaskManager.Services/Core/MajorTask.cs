using Quartz;

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

namespace AWen.TaskManager.Services.Core
{
    public class MajorTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //System.Console.WriteLine(System.Threading.Thread.CurrentThread.Name);
            QuartzManager.TaskManager(context.Scheduler);
        }
    }
}