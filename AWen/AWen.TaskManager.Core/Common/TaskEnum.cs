﻿/********************************************************************
 * 命名空间: AWen.TaskManager.Core.Common

 * 文件名称: TaskState

 * 文件作者: Young

 * 创建时间: 2018/4/13 10:13:37
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

namespace AWen.TaskManager.Core.Common
{
    //Task状态
    public enum TaskState : int
    {
        /// <summary>
        /// 停止 表示任务结束运行最终状态
        /// </summary>
        Stopped = -20,

        /// <summary>
        /// 停止中 表示任务即将进入停止运行的临时状态
        /// </summary>
        Stopping = -10,


        /// <summary>
        /// 初始状态 表示任务刚创建或者编辑后初始状态
        /// </summary>
        Initial = 0,

        /// <summary>
        /// /开始及启动中 表示任务即将进入运行中的临时状态
        /// </summary>
        Starting = 10,

        /// <summary>
        /// 运行中 表示任务运行中的状态
        /// </summary>
        Running = 20,

        /// <summary>
        /// 错误 表示任务运行错误(预留状态暂时不启用)
        /// </summary>
        Error = -100
    }

    public enum TaskType
    {
        /// <summary>
        /// 请求url的任务
        /// </summary>
        Url,

        /// <summary>
        /// exe可执行文件的任务
        /// </summary>
        Exe,

        /// <summary>
        /// 实现ijob接口dll任务
        /// </summary>
        IJob
    }
}