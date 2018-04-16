/********************************************************************
 * 命名空间: AWen.TaskManager.Core.Interface

 * 文件名称: ITaskLogRepository

 * 文件作者: AWen

 * 创建时间: 2018/4/13 11:22:36
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.Interface;
namespace AWen.TaskManager.Core.DAL
{
    public interface ITaskLogRepository:IBaseRepository<Model.TB_TM_TaskLog,int>
    {
    }
}