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

        public PKey Add(T entity)
        {
            //do nothing
            return default(PKey);
        }

        public bool Update(T entity)
        {
            //do nothing
            return false;
        }

        public bool Update(string strWhere, object parameters)
        {
            //do nothing
            return false;
        }

        public bool Delete(PKey key)
        {
            //do nothing
            return false;
        }

        public bool Delete(string strWhere, object parameters)
        {
            //do nothing
            return false;
        }

        public T Get(PKey key)
        {
            //do nothing
            return null;
        }

        public T Get(string strWhere, object parameters)
        {
            //do nothing
            return null;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            //do nothing
            return null;
        }

        public System.Collections.Generic.IEnumerable<T> GetList(string strWhere, object parameters)
        {
            //do nothing
            return null;
        }

        public System.Collections.Generic.IEnumerable<T> GetPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters, out int countNum)
        {
            countNum = 0;
            //do nothing
            return null;
        }

        public int Count(string strWhere, object parameters)
        {
            //do nothing
            return 0;
        }
    }
}