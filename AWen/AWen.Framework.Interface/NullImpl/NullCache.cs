/********************************************************************
 * 命名空间:AWen.Framework.Interface.NullImpl

 * 文件名称: NullCache

 * 文件作者: Young

 * 创建时间: 2018/4/22 16:00:42
=====================================================================
 * 功能说明:  空缓存实现类
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System.Collections.Generic;

namespace AWen.Framework.Interface.NullImpl
{
    /// <summary>
    ///  空缓存实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullCache<T> : ICache<T> where T : class
    {
        public IEnumerable<T> Gets(string key)
        {
            //do nothing
            return null;
        }

        public T Get(string key)
        {
            //do nothing
            return null;
        }

        public bool Sets(string key, IEnumerable<T> value, System.TimeSpan expiresIn)
        {
            //do nothing
            return false;
        }

        public bool Set(string key, T value, System.TimeSpan expiresIn)
        {
            //do nothing
            return false;
        }

        public bool Remove(string key)
        {
            //do nothing
            return false;
        }
    }
}