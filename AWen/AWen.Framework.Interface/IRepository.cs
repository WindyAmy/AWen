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
using System.Linq.Expressions;

namespace AWen.Framework.Interface
{
    public interface IRepository<T, PKey> where T : class
    {
        bool Add(T entity);

        bool AddBatch(IEnumerable<T> entitys);

        bool Update(T entity);

        bool Update(Expression<Func<T, bool>> func);

        bool Delete(PKey key);

        bool Delete(Expression<Func<T, bool>> func);

        T Get(PKey key);

        T Get(Expression<Func<T, bool>> func);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetList(Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> order = null);

        Tuple<int, IEnumerable<T>> GetPage(int pageNum, int rowsNum, Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> order = null);

        long Count(Expression<Func<T, bool>> where = null);
    }
}