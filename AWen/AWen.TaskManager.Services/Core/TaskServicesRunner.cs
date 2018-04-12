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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AWen.TaskManager.Services.Core
{
    public class TaskServicesRunner : ServiceControl, ServiceSuspend
    {

        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("Start");
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
