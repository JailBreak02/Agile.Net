using AopAlliance.Intercept;
using AopGlobal.Common;
using Entities.Entity;
using LogManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AopGlobal.Aspects
{
    public class AroundAdvice : IMethodInterceptor
    {
        private Logger logger = Logger.Instance;

        public object Invoke(IMethodInvocation invocation)
        {
            // 方法是否异常
            // 调用无异常 true 调用有异常 false
            bool succeed = true;

            // 异常信息
            Exception exception = null;

            // 调用时间
            DateTime invokedTime = DateTime.Now;

            // 消耗的时间
            double elapsedTime = default(double);

            object returnValue = null;
            Stopwatch stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();
                returnValue = invocation.Proceed();
                stopWatch.Stop();
            }
            catch (Exception ex)
            {
                // 赋值 succeed 标示方法出现异常
                succeed = false;
                // 赋值异常信息
                exception = ex;
                // 异常时停止 Stopwatch
                if (stopWatch.IsRunning)
                {
                    stopWatch.Stop();
                }

                // 异常详细信息额外记录在单独日志文件中
                // 其余的通用信息在 通用日志处理逻辑 中记录
                string message = string.Format("{0} 中的 {1} 方法出现异常", invocation.TargetType.Name, invocation.Method.Name);
                logger.Error(message, ex);
            }

            // 通用日志处理逻辑
            try
            {
                // 赋值消耗的时间
                elapsedTime = stopWatch.Elapsed.TotalMilliseconds;

                returnValue = ProcessBusin(invocation, returnValue, succeed, invokedTime, elapsedTime, exception);
            }
            catch (Exception ex)
            {
                string message = "通用日志处理逻辑发生异常";
                logger.Error(message, ex);
            }

            return returnValue;
        }

        #region 私有方法

        /// <summary>
        /// 通用日志处理逻辑
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="returnValue"></param>
        /// <param name="succeed"></param>
        /// <param name="invokedTime"></param>
        /// <param name="elapsedTime"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private object ProcessBusin(IMethodInvocation invocation, object returnValue, bool succeed, DateTime invokedTime, double elapsedTime, Exception exception)
        {
            // 判断返回类型是否为ResultInfo<T>
            bool isResultInfo = default(bool);
            if (invocation.Method.ReturnType.Name.Equals("ResultInfo`1"))
            {
                isResultInfo = true;
            }

            // 如果返回对象为null 比如方法异常时会到导致返回对象为 null
            if (returnValue == null)
            {
                // 初始化返回值对象
                returnValue = Activator.CreateInstance(invocation.Method.ReturnType);
            }

            PropertyInfo piSucceed = null;
            PropertyInfo piMessage = null;
            PropertyInfo piResult = null;

            if (isResultInfo)
            {
                #region 通过反射解析对象属性

                piSucceed = invocation.Method.ReturnType.GetProperty("Succeed");
                piMessage = invocation.Method.ReturnType.GetProperty("Message");
                piResult = invocation.Method.ReturnType.GetProperty("Result");

                // 执行异常时，设置对应的属性值
                // 设置返回值的Succeed属性为false, Message属性为异常信息
                if (!succeed)
                {
                    if (piSucceed != null)
                    {
                        piSucceed.SetValue(returnValue, false, null);
                    }
                    if (piMessage != null)
                    {
                        piMessage.SetValue(returnValue, TooltipMessages.ExceptionOccur, null);
                    }

                    // 如果结果是bool值，则将结果设置为false
                    if (piResult != null && piResult.GetType() == typeof(bool))
                    {
                        piResult.SetValue(returnValue, false, null);
                    }
                }

                #endregion
            }

            // 创建日志记录对象
            InteractionLog log = new InteractionLog();
            log.Succeed = succeed;
            log.InvokedTime = invokedTime;
            log.ElapsedTime = elapsedTime.ToString();

            log.Operation = LogUtil.GetOperation(invocation);
            log.InvokedAddress = LogUtil.GetInvokedAddress();
            log.Arguments = LogUtil.GetArgument(invocation);
            log.Message = isResultInfo ? LogUtil.GetMessage(returnValue, succeed, piMessage, exception) : LogUtil.GetMessage(returnValue, succeed, exception);
            log.Result = isResultInfo ? LogUtil.GetResult(returnValue, succeed, piResult) : LogUtil.GetResult(returnValue, succeed);

            // 记录日志信息
            logger.Info(log);

            return returnValue;
        }

        #endregion
    }
}
