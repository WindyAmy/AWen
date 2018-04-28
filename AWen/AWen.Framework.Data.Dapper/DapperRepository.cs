using AWen.Framework.Interface;
using Dapper;

/********************************************************************
 * 命名空间: AWen.Framework.Data.Dapper

 * 文件名称: DapperRepository

 * 文件作者: Young

 * 创建时间: 2018/4/23 16:38:48
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AWen.Framework.Data.Dapper
{
    public class DapperRepository<T, PKey> : IRepository<T, PKey> where T : class
    {
        private IDbConnection _connection;

        public DapperRepository()
        {
            _connection = DbConnectionFactory.CreateDbConnection();
        }

        public void SetDbConnection(IDbConnection connection)
        {
            _connection = connection;
        }

        public PKey Add(T entity)
        {
            PKey result = default(PKey);
            using (_connection)
            {
                result = _connection.Insert<PKey>(entity);
            }
            return result;
        }

        public bool Update(T entity)
        {
            using (_connection)
            {
                return _connection.Update(entity) > 0 ? true : false;
            }
        }

        public bool Update(string strWhere, object parameters)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PKey key)
        {
            using (_connection)
            {
                return _connection.Delete<T>(key) > 0 ? true : false;
            }
        }

        public bool Delete(string strWhere, object parameters)
        {
            using (_connection)
            {
                return _connection.DeleteList<T>(strWhere, parameters) > 0 ? true : false;
            }
        }

        public T Get(PKey key)
        {
            using (_connection)
            {
                return _connection.Get<T>(key);
            }
        }

        public T Get(string strWhere, object parameters)
        {
            using (_connection)
            {
                return _connection.GetList<T>(strWhere, parameters).SingleOrDefault();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (_connection)
            {
                return _connection.GetList<T>();
            }
        }

        public IEnumerable<T> GetList(string strWhere, object parameters)
        {
            using (_connection)
            {
                return _connection.GetList<T>(strWhere, parameters);
            }
        }

        public IEnumerable<T> GetPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters, out int countNum)
        {
            countNum = 0;
            countNum = Count(strWhere, parameters);
            return _connection.GetListPaged<T>(pageNum, rowsNum, strWhere, orderBy, parameters);
        }

        public int Count(string strWhere, object parameters)
        {
            using (_connection)
            {
                return _connection.GetList<T>(strWhere, parameters).Count();
            }
        }
    }
}