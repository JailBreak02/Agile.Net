using Spring.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Aspects
{
    public class ThrowsAdvice : IThrowsAdvice
    {
        public void AfterThrowing(Exception ex)
        {
            Console.Error.WriteLine(
                String.Format("Advised method threw this exception : {0}", ex.Message));
        }
    }
}
