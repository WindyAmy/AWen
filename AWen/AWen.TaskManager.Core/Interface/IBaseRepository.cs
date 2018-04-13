/********************************************************************
 * 命名空间: AWen.TaskManager.Core.Interface

 * 文件名称: IBaseRepository

 * 文件作者: Young

 * 创建时间: 2018/4/13 10:39:48
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System.Collections.Generic;

namespace AWen.TaskManager.Core.Interface
{
    /// <summary>
    /// 仓储Repository接口
    /// </summary>
    public interface IBaseRepository<T, PKey> //where T : IModel
    {
        #region 成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(T model);

        /// <summary>
        /// 根据key删除一条数据
        /// </summary>
        bool Delete(PKey key);

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool DeleteList(string strWhere, object parameters);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(T model);

        /// <summary>
        /// 根据key获取实体对象
        /// </summary>
        T GetModel(PKey key);

        ///// <summary>
        ///// 根据条件获取实体对象
        ///// </summary>
        //T GetModel(string strWhere, object parameters);
        /// <summary>
        /// 根据条件获取实体对象集合
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> GetModelList(string strWhere, object parameters);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="rowsNum">每页行数</param>
        /// <param name="strWhere">where条件</param>
        /// <param name="orderBy">Orde by排序</param>
        /// <param name="parameters">parameters参数</param>
        /// <returns></returns>
        IEnumerable<T> GetListPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters);

        #endregion 成员方法
    }
}