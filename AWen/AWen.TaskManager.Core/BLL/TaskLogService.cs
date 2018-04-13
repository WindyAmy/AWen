/********************************************************************
 * 命名空间: AWen.TaskManager.Core.DAL

 * 文件名称: TaskLogRepository

 * 文件作者: AWen

 * 创建时间: 2018/4/13 11:20:14
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.DAL;
using AWen.TaskManager.Core.Interface;
namespace AWen.TaskManager.Core.BLL
{
    public class TaskLogRepository : GuidRepository<Model.TB_TM_TaskLog>, ITaskLogRepository
    {
    }
}