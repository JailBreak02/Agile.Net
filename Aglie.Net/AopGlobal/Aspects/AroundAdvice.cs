using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Aspects
{
    public class AroundAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            Console.Out.WriteLine(String.Format(
                "Intercepted call : about to invoke method '{0}'", invocation.Method.Name));

            object returnValue = invocation.Proceed();

            Console.Out.WriteLine(String.Format(
                "Intercepted call : returned '{0}'", returnValue));

            return returnValue;
        }
    }
}
