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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWen.TaskManager.Services.Core
{
    public class MajorTask : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("this is time"+DateTime.Now);
            return null;
        }
    }
}
