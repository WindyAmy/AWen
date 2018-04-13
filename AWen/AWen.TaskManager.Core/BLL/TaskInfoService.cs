using AWen.TaskManager.Core.DAL;
/******************************************************************** 
 * 命名空间: AWen.TaskManager.Core.BLL

 * 文件名称: TaskInfoService

 * 文件作者: Young
 
 * 创建时间: 2018/4/13 11:29:40
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

namespace AWen.TaskManager.Core.BLL
{
    public class TaskInfoService : GuidRepository<Model.TB_TM_TaskInfo>, ITaskInfoRepository 
    {

    }
}
