/********************************************************************
 * 命名空间: AWen.Framework.Interface.NullImpl

 * 文件名称: NullLogger

 * 文件作者: AWen

 * 创建时间: 2018/4/22 15:56:48
=====================================================================
 * 功能说明: 空日志实现类
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;

namespace AWen.Framework.Interface.NullImpl
{
    /// <summary>
    /// 空日志实现类
    /// </summary>
    public class NullLogger : ILogger
    {
        public void Info(object message)
        {
            //do nothing
        }

        public void Info(object message, Exception e)
        {
            //do nothing
        }

        public void Debug(object message)
        {
            //do nothing
        }

        public void Debug(object message, Exception e)
        {
            //do nothing
        }

        public void Warn(object message)
        {
            //do nothing
        }

        public void Warn(object message, Exception e)
        {
            //do nothing
        }

        public void Error(object message)
        {
            //do nothing
        }

        public void Error(object message, Exception e)
        {
            //do nothing
        }

        public void Fatal(object message)
        {
            //do nothing
        }

        public void Fatal(object message, Exception e)
        {
            //do nothing
        }
    }
}