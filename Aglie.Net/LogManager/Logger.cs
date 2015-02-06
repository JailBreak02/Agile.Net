using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4netConfig.xml", Watch = true)]

namespace LogManager
{
    /// <summary>
    /// 日志对象
    /// </summary>
    public class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // 时间戳(验证单例)
        private string _createdTimestamp;
        private static Logger _instance;
        // Creates an syn object.
        private static readonly object SynObject = new object();

        /// <summary>
        /// 无参数的构造函数
        /// </summary>
        public Logger()
        {
            _createdTimestamp = DateTime.Now.ToString();
        }

        /// <summary>
        /// 公共单例实例
        /// </summary>
        public static Logger Instance
        {
            get
            {
                // Double-Checked Locking
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Info级别日志入口
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            if (log.IsInfoEnabled) log.Info(message);
        }

        /// <summary>
        /// Debug级别日志入口
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            if (log.IsDebugEnabled) log.Debug(message);
        }

        /// <summary>
        /// Error级别日志入口
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            if (log.IsErrorEnabled) log.Error(message);
        }

        /// <summary>
        /// Error级别日志入口
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            if (log.IsErrorEnabled) log.Error(message, exception);
        }

        /// <summary>
        /// Warn级别日志入口
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            if (log.IsWarnEnabled) log.Warn(message);
        }
    }
}
