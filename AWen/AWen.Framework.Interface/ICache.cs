/********************************************************************
 * 命名空间: AWen.Framework.Interface

 * 文件名称: ICache

 * 文件作者: AWen

 * 创建时间: 2018/4/22 8:43:04
=====================================================================
 * 功能说明: 缓存接口
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;
using System.Collections.Generic;

namespace AWen.Framework.Interface
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICache<T> where T : class
    {
        IEnumerable<T> Gets(string key);

        T Get(string key);

        bool Sets(string key, IEnumerable<T> value, TimeSpan expiresIn);

        bool Set(string key, T value, TimeSpan expiresIn);

        bool Remove(string key);
    }
}