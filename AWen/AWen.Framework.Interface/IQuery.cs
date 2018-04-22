/******************************************************************** 
 * 命名空间: AWen.Framework.Interface

 * 文件名称: IQuery

 * 文件作者: AWen
 
 * 创建时间: 2018/4/22 9:26:08
=====================================================================
 * 功能说明: 查询接口
--------------------------------------------------------------------- 
 * 其他说明:
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWen.Framework.Interface
{
    public interface IQuery
    {
        T QuerySingle<T>(string sql, object paramPairs) where T : class;
        IEnumerable<T> QueryList<T>(string sql, object paramPairs) where T : class;

        /// <summary>必须带上row_number() over({0}) RowNumber</summary>
        Tuple<int, IEnumerable<T>> GetPage<T>(int pageNum, int rowsNum, string sql, dynamic paramPairs = null) where T : class;

        Tuple<int, IEnumerable<T>> GetPage<T>(string sql, object paramPairs = null) where T : class;
        int Execute(string sql, dynamic paramPairs = null);
        long Count(string sql, dynamic paramPairs = null);
    }
}
