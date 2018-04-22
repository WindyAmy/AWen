/********************************************************************
 * 命名空间: AWen.Framework.Interface

 * 文件名称: ILogger

 * 文件作者: AWen

 * 创建时间: 2018/4/22 8:49:30
=====================================================================
 * 功能说明: 日志接口
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;

namespace AWen.Framework.Interface
{
    public interface ILogger
    {
        void Info(object message);

        void Info(object message, Exception e);

        void Debug(object message);

        void Debug(object message, Exception e);

        void Warn(object message);

        void Warn(object message, Exception e);

        void Error(object message);

        void Error(object message, Exception e);

        void Fatal(object message);

        void Fatal(object message, Exception e);
    }
}