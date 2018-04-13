using AWen.TaskManager.Core.Common;
using AWen.TaskManager.Core.Interface;
using Dapper;
/********************************************************************
 * 命名空间: AWen.TaskManager.Core.DAL

 * 文件名称: BaseRepository

 * 文件作者: Young

 * 创建时间: 2018/4/13 10:45:21
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace AWen.TaskManager.Core.DAL
{
    /// <summary>
    /// 仓储层基类，通过泛型实现通用的CRUD操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T, PKey> : IBaseRepository<T, PKey>
    {
        private IDbConnection _connection;

        #region 成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T model)
        {
            PKey result;
            using (_connection = Database.GetOpenConnection())
            {
                result = _connection.Insert<PKey>(model);
            }
            return true;
            //if (result > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 根据key删除一条数据
        /// </summary>
        public bool Delete(PKey key)
        {
            int? result;
            using (_connection = Database.GetOpenConnection())
            {
                result = _connection.Delete<T>(key);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 按条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool DeleteList(string strWhere, object parameters)
        {
            int? result;
            using (_connection = Database.GetOpenConnection())
            {
                result = _connection.DeleteList<T>(strWhere, parameters);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T model)
        {
            int? result;
            using (_connection = Database.GetOpenConnection())
            {
                result = _connection.Update(model);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据key获取实体对象
        /// </summary>
        public T GetModel(PKey key)
        {
            using (_connection = Database.GetOpenConnection())
            {
                return _connection.Get<T>(key);
            }
        }

        /// <summary>
        /// 根据条件获取实体对象集合
        /// </summary>
        public IEnumerable<T> GetModelList(string strWhere, object parameters)
        {
            using (_connection = Database.GetOpenConnection())
            {
                return _connection.GetList<T>(strWhere, parameters);
            }
        }

        /// <summary>
        /// 根据条件分页获取实体对象集合
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="rowsNum"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters)
        {
            using (_connection = Database.GetOpenConnection())
            {
                return _connection.GetListPaged<T>(pageNum, rowsNum, strWhere, orderBy, parameters); ;
            }
        }

        #endregion 成员方法
    }

}