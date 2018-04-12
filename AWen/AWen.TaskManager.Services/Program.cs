using AWen.TaskManager.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AWen.TaskManager.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
           var host= HostFactory.New(a => {
               a.Service<TaskServicesRunner>();
            });
           host.Run();
        }
    }
}
