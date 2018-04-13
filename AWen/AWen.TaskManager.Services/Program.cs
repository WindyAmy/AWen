using AWen.TaskManager.Core.BLL;
using System;

namespace AWen.TaskManager.Services
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TaskInfoService _TaskInfoService = new TaskInfoService();
            _TaskInfoService.Add(new TaskManager.Core.Model.TB_TM_TaskInfo()
            {
                TaskId = Guid.NewGuid(),
                TaskName = "TEST",
                //CreatedDateTime = DateTime.Now,
                //LastUpdatedDateTime = DateTime.Now,
                //LastRunTime = DateTime.Now,
                //NextRunTime=DateTime.Now
            });
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            //var host= HostFactory.New(a => {
            //    a.Service<TaskServicesRunner>();
            // });
            //host.Run();
        }
    }
}