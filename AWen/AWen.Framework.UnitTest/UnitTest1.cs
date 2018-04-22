using AWen.Framework.Infrastructure;
using AWen.Framework.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AWen.Framework.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCache()
        {
            User u = new User();
            u.ID = 100;
            u.Name = "王文定";
            var cache = ProviderHelper.GetCacheProvider<User>();
            cache.Set("test", u, TimeSpan.FromSeconds(50));

            var cacheu = cache.Get("test");
            Console.WriteLine(u.ID);
            Assert.AreEqual(u, cacheu);
        }

        [TestMethod]
        public void TestLog()
        {
            User u = new User();
            u.ID = 100;
            u.Name = "王文定";

            ILogger log = ProviderHelper.GetLoggerProvider();
            Console.WriteLine(log.GetType());
            log.Info(u);
        }
    }
}