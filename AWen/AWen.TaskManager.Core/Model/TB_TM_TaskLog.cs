/********************************************************************
 * 命名空间: AWen.TaskManager.Core.Model

 * 文件名称: TB_TM_TaskLog

 * 文件作者: AWen

 * 创建时间: 2018/4/13 10:07:02
=====================================================================
 * 功能说明:  任务日志表
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.Interface;
using AWen.TaskManager.Core.Model.Base;
using Dapper;
using System;

namespace AWen.TaskManager.Core.Model
{
    public class TB_TM_TaskLog : BaseModel, IModel
    {

        /// <summary>
        /// TaskID
        /// </summary>
        [Key]
        public int TaskLogId { get; set; }

        /// <summary>
        /// TaskID
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Task名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public Nullable<DateTime> ExecutionTime { get; set; }

        /// <summary>
        /// 执行持续时长
        /// </summary>
        public Nullable<double> ExecutionDuration { get; set; }

        /// <summary>
        /// 创建日期时间
        /// </summary>
        public System.DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string RunLog { get; set; }

        /// <summary>
        /// 是否删除 0-未删除   1-已删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}