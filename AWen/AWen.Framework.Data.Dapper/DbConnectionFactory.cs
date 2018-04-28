/******************************************************************** 
 * 命名空间: AWen.Framework.Data.Dapper

 * 文件名称: DbConnectionFactory

 * 文件作者: Young
 
 * 创建时间: 2018/4/23 16:41:51
=====================================================================
 * 功能说明: 
--------------------------------------------------------------------- 
 * 其他说明:
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWen.Framework.Data.Dapper
{
    public class DbConnectionFactory
    {
        private static readonly string connectionString;
        private static readonly string databaseType;

        static DbConnectionFactory()
        {
            var collection = ConfigurationManager.ConnectionStrings["connectionString"];
            connectionString = collection.ConnectionString;
            databaseType = collection.ProviderName.ToLower();
        }

        public static IDbConnection CreateDbConnection()
        {
            IDbConnection connection = null;
            switch (databaseType)
            {
                case "system.data.sqlclient":
                    connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
                case "mysql":
                    //connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    break;
                case "oracle":
                    //connection = new Oracle.DataAccess.Client.OracleConnection(connectionString);
                    //connection = new System.Data.OracleClient.OracleConnection(connectionString);
                    break;
                case "db2":
                    connection = new System.Data.OleDb.OleDbConnection(connectionString);
                    break;
                default:
                    connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
            }
            if(connection!=null)
            {
                if(connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            return connection;
        }
    }
}
