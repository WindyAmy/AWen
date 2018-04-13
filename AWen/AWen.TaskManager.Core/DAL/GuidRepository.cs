using AWen.TaskManager.Core.Interface;

/********************************************************************
 * 命名空间: AWen.TaskManager.Core.DAL

 * 文件名称: GuidRepository

 * 文件作者: AWen

 * 创建时间: 2018/4/13 11:14:18
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;

namespace AWen.TaskManager.Core.DAL
{
    public class GuidRepository<T> : BaseRepository<T, Guid>, IBaseRepository<T, Guid>
    {
    }
}