using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AopGlobal.Aspects
{
    public class AroundAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            /*
            Console.Out.WriteLine(String.Format(
                "Intercepted call : about to invoke method '{0}'", invocation.Method.Name));

            object returnValue = invocation.Proceed();

            Console.Out.WriteLine(String.Format(
                "Intercepted call : returned '{0}'", returnValue));

            return returnValue;
             */

            // 方法是否异常
            bool succeed = true;

            // 异常信息
            Exception exception = null;

            object returnValue = null;
            Stopwatch stopWatch = new Stopwatch();

            try
            {
                returnValue = invocation.Proceed();
            }
            catch (Exception ex)
            {
                // 赋值 succeed 标示方法出现异常
                succeed = false;
                // 赋值异常信息
                exception = ex;
                // 异常详细信息额外记录在单独日志文件中
                // 其余的通用信息在通用日志处理逻辑中记录
                
            }

            return returnValue;
        }
    }
}
