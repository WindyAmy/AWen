/********************************************************************
 * 命名空间: AWen.TaskManager.Core.Model

 * 文件名称: TB_TM_TaskInfo

 * 文件作者: AWen

 * 创建时间: 2018/4/13 9:51:20
=====================================================================
 * 功能说明: 任务信息表
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using AWen.TaskManager.Core.Interface;
using AWen.TaskManager.Core.Model.Base;
using Dapper;
using System;

namespace AWen.TaskManager.Core.Model
{
    public class TB_TM_TaskInfo : BaseModel, IModel
    {
        /// <summary>
        /// TaskID
        /// </summary>
        [Key]
        public string TaskId { get; set; }

        /// <summary>
        /// Task类型
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// Task名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 程序集名称(所属程序集)
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 类名(完整命名空间的类名)
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string TaskArgs { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// Cron表达式描述
        /// </summary>
        public string CronExpressionDescription { get; set; }

        /// <summary>
        /// 最后运行时间
        /// </summary>
        public DateTime? LastRunTime { get; set; }

        /// <summary>
        /// 下次运行时间
        /// </summary>
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// 运行次数
        /// </summary>
        public int RunCount { get; set; }

        /// <summary>
        /// 状态  0-停止  1-运行   3-正在启动中...   5-停止中...
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreatedByUserId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// 创建日期时间
        /// </summary>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// 最后更新人ID
        /// </summary>
        public string LastUpdatedByUserId { get; set; }

        /// <summary>
        /// 最后更新人姓名
        /// </summary>
        public string LastUpdatedByUserName { get; set; }

        ///// <summary>
        ///// 最后更新时间
        ///// </summary>
        public DateTime? LastUpdatedDateTime { get; set; }

        /// <summary>
        /// 是否删除 0-未删除   1-已删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}