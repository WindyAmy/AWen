/********************************************************************
 * 命名空间: AWen.Framework.Interface

 * 文件名称: IRepository

 * 文件作者: Young

 * 创建时间: 2018/4/22 9:44:39
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;
using System.Collections.Generic;

namespace AWen.Framework.Interface
{
    public interface IRepository<T, PKey> where T : class
    {
        PKey Add(T entity);

        bool Update(T entity);

        bool Update(string strWhere, object parameters);

        bool Delete(PKey key);

        bool Delete(string strWhere, object parameters);

        T Get(PKey key);

        T Get(string strWhere, object parameters);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetList(string strWhere, object parameters);

        IEnumerable<T> GetPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters, out int countNum);

        int Count(string strWhere, object parameters);
    }
}