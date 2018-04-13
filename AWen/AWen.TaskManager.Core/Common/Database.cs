/******************************************************************** 
 * 命名空间: AWen.TaskManager.Core.Common

 * 文件名称: DB

 * 文件作者: Young
 
 * 创建时间: 2018/4/13 11:11:09
=====================================================================
 * 功能说明: 
--------------------------------------------------------------------- 
 * 其他说明:
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWen.TaskManager.Core.Common
{
    public class Database
    {
        /// 得到web.config里配置项的数据库连接字符串。
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        /// 得到工厂提供器类型
        private static readonly string ProviderFactoryString = ConfigurationManager.AppSettings["DBProvider"].ToString();

        private static DbProviderFactory df = null;

        /// <summary>
        /// 创建工厂提供器并且
        /// </summary>
        public static IDbConnection GetOpenConnection()
        {
            if (df == null)
                df = DbProviderFactories.GetFactory(ProviderFactoryString);
            var connection = df.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            return connection;
        }
    }
}
