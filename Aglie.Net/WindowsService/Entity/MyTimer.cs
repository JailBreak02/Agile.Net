using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsService.Entity
{
    /// <summary>
    /// 带有自定义参数的System.Timers.Timer 
    /// </summary>
    public class MyTimer : System.Timers.Timer
    {
        public ThreadParam ThreadParam { get; set; }

        public TimerParam TimerParam { get; set; }

    }
}
