using Spring.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AopGlobal.Aspects
{
    public class BeforeAdvice : IMethodBeforeAdvice
    {
        public void Before(MethodInfo method, object[] args, object target)
        {
            Console.Out.WriteLine("Intercepted call to this method : " + method.Name);
            Console.Out.WriteLine("    The target is       : " + target);
            Console.Out.WriteLine("    The arguments are   : ");
            if (args != null)
            {
                foreach (object arg in args)
                {
                    Console.Out.WriteLine("\t: " + arg);
                }
            }
        }
    }
}
