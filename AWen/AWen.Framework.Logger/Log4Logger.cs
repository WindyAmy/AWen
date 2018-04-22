using AWen.Framework.Interface;
using log4net;

/********************************************************************
 * 命名空间: AWen.Framework.Logger

 * 文件名称: Log4Logger

 * 文件作者: AWen

 * 创建时间: 2018/4/22 15:49:53
=====================================================================
 * 功能说明:  log4net 日志实现类
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;

namespace AWen.Framework.Logger
{
    public class Log4Logger : ILogger
    {
        private ILog logger;

        public Log4Logger()
        {
            logger = LogManager.GetLogger("log4netlogger");
        }

        public void Info(object message)
        {
            logger.Info(message);
        }

        public void Info(object message, Exception e)
        {
            logger.Info(message, e);
        }

        public void Debug(object message)
        {
            logger.Debug(message);
        }

        public void Debug(object message, Exception e)
        {
            logger.Debug(message, e);
        }

        public void Warn(object message)
        {
            logger.Warn(message);
        }

        public void Warn(object message, Exception e)
        {
            logger.Warn(message, e);
        }

        public void Error(object message)
        {
            logger.Error(message);
        }

        public void Error(object message, Exception e)
        {
            logger.Error(message, e);
        }

        public void Fatal(object message)
        {
            logger.Fatal(message);
        }

        public void Fatal(object message, Exception e)
        {
            logger.Fatal(message, e);
        }
    }
}