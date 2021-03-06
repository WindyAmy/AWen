﻿using AWen.TaskManager.Core.Interface;
/******************************************************************** 
 * 命名空间: AWen.TaskManager.Core.Interface

 * 文件名称: ITaskInfoRepository

 * 文件作者: AWen
 
 * 创建时间: 2018/4/13 11:21:40
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
    public interface ITaskInfoRepository : IBaseRepository<Model.TB_TM_TaskInfo, int>
    {
    }
}
