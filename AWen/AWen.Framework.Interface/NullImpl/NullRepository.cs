/********************************************************************
 * 命名空间: AWen.Framework.Interface.NullImpl

 * 文件名称: NullRepository

 * 文件作者: Young

 * 创建时间: 2018/4/22 16:18:04
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

namespace AWen.Framework.Interface.NullImpl
{
    public class NullRepository<T, PKey> : IRepository<T, PKey> where T : class
    {
        public bool Add(T entity)
        {
            //do nothing
            return false;
        }

        public bool AddBatch(System.Collections.Generic.IEnumerable<T> entitys)
        {
            //do nothing
            return false;
        }

        public bool Update(T entity)
        {
            //do nothing
            return false;
        }

        public bool Update(System.Linq.Expressions.Expression<System.Func<T, bool>> func)
        {
            //do nothing
            return false;
        }

        public bool Delete(PKey key)
        {
            //do nothing
            return false;
        }

        public bool Delete(System.Linq.Expressions.Expression<System.Func<T, bool>> func)
        {
            //do nothing
            return false;
        }

        public T Get(PKey key)
        {
            //do nothing
            return null;
        }

        public T Get(System.Linq.Expressions.Expression<System.Func<T, bool>> func)
        {
            //do nothing
            return null;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            //do nothing
            return null;
        }

        public System.Collections.Generic.IEnumerable<T> GetList(System.Linq.Expressions.Expression<System.Func<T, bool>> where = null, System.Linq.Expressions.Expression<System.Func<T, bool>> order = null)
        {
            //do nothing
            return null;
        }

        public System.Tuple<int, System.Collections.Generic.IEnumerable<T>> GetPage(int pageNum, int rowsNum, System.Linq.Expressions.Expression<System.Func<T, bool>> where = null, System.Linq.Expressions.Expression<System.Func<T, bool>> order = null)
        {
            //do nothing
            return null;
        }

        public long Count(System.Linq.Expressions.Expression<System.Func<T, bool>> where = null)
        {
            //do nothing
            return 0;
        }
    }
}