using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Entity
{
    public class TooltipMessages
    {

        private static string _exceptionOccur = "系统出现错误，正在解决... 请您稍后再试!";

        public static string ExceptionOccur { get { return _exceptionOccur; } set { _exceptionOccur = value; } }
    }
}
