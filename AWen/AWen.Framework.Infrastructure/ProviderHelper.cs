using Autofac;
using AWen.Framework.Cache;
using AWen.Framework.Interface;
using AWen.Framework.Interface.NullImpl;

/********************************************************************
 * 命名空间: AWen.Framework.Infrastructure

 * 文件名称: ProviderHelper

 * 文件作者: AWen

 * 创建时间: 2018/4/22 11:11:20
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

namespace AWen.Framework.Infrastructure
{
    public class ProviderHelper
    {
        private static IContainer Container { get; set; }

        static ProviderHelper()
        {
            var builder = new ContainerBuilder();
         
            builder.RegisterType<NullLogger>().As<ILogger>();
            builder.RegisterGeneric(typeof(NullCache<>)).As(typeof(ICache<>));
            builder.RegisterGeneric(typeof(HttpRuntimeCache<>)).As(typeof(ICache<>));
            builder.RegisterGeneric(typeof(NullRepository<,>)).As(typeof(IRepository<,>));
            Container = builder.Build();
        }

        public static ICache<T> GetCacheProvider<T>() where T : class
        {
            ICache<T> obj = Container.Resolve<ICache<T>>();
            return obj;
        }

        public static ILogger GetLoggerProvider()
        {
            ILogger obj = Container.Resolve<ILogger>();
            return obj;
        }

        public static IRepository<T, PKey> GetRepositoryProvider<T, PKey>() where T : class
        {
            IRepository<T, PKey> obj = Container.Resolve<IRepository<T, PKey>>();
            return obj;
        }
    }
}