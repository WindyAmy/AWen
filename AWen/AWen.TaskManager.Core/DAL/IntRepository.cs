using AWen.TaskManager.Core.Interface;
/******************************************************************** 
 * 命名空间: AWen.TaskManager.Core.DAL

 * 文件名称: IntRepository

 * 文件作者: AWen
 
 * 创建时间: 2018/4/16 8:24:52
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

namespace AWen.TaskManager.Core.DAL
{
    public class IntRepository<T> : BaseRepository<T, int>, IBaseRepository<T, int>
    {
    }
}
