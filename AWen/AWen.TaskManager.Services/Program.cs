using AWen.TaskManager.Services.Core;
using Topshelf;

namespace AWen.TaskManager.Services
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "/Config/log4net.config"));
            var host = HostFactory.New(x =>
            {
                // x.UseLog4Net();
                x.RunAsLocalSystem();
                x.Service<TaskServicesRunner>();
                x.SetDescription(string.Format("{0} Ver:{1}", System.Configuration.ConfigurationManager.AppSettings.Get("ServiceDescription"), System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                x.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceDisplayName"));
                x.SetServiceName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName"));
                x.EnablePauseAndContinue();
            });
            host.Run();
        }
    }
}