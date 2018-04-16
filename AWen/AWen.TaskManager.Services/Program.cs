using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Services.Core;
using System;
using Topshelf;

namespace AWen.TaskManager.Services
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           // TaskInfoService _TaskInfoService = new TaskInfoService();
           //var list= _TaskInfoService.GetModelList(" WHERE  1=1", null);
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            var host = HostFactory.New(a =>
            {
                a.Service<TaskServicesRunner>();
            });
            host.Run();
            //var Response = HttpHelper.CreatePostHttpResponse("http://localhost:22960/WebForm1.aspx", null);
            //System.Console.WriteLine(HttpHelper.GetResponseString(Response));
            //Console.ReadLine();
        }
    }
}