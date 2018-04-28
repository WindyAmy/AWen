/******************************************************************** 
 * 命名空间: AWen.Framework.Interface

 * 文件名称: IUnitOfWork

 * 文件作者: Young
 
 * 创建时间: 2018/4/24 10:26:17
=====================================================================
 * 功能说明: 
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
    public interface IUnitOfWork
    {
        IQueryable<T> Set<T>() where T : class;
        T Add<T>(T entity) where T : class;
        T Attach<T>(T entity) where T : class;
        T Remove<T>(T entity) where T : class;
        void Commit();
        void Rollback();
        //IDbContext Context { get; set; }//也有人添加这个
    }
}
