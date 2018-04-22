using AWen.Framework.Interface;
/******************************************************************** 
 * 命名空间: AWen.Framework.Infrastructure

 * 文件名称: Cache

 * 文件作者: Young
 
 * 创建时间: 2018/4/22 10:57:35
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

namespace AWen.Framework.Infrastructure
{
    public sealed class Cache<T> where T : class
    {
        private readonly static ICache<T> cacheProvider;

        static Cache()
        {
            cacheProvider = ProviderHelper.GetCacheProvider<T>();
        }

        public static IEnumerable<T> Gets(string key)
        {
            return cacheProvider.Gets(key);
        }

        public static T Get(string key)
        {
            return cacheProvider.Get(key);
        }

        public static bool Sets(string key, IEnumerable<T> value, TimeSpan expiresIn)
        {
            return cacheProvider.Sets(key, value, expiresIn);
        }

        public static bool Set(string key, T value, TimeSpan expiresIn)
        {
            return cacheProvider.Set(key, value, expiresIn);
        }

        public static bool Remove(string key)
        {
            return cacheProvider.Remove(key);
        }
    }
}
