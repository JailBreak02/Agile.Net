using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using WindowsService.Entity;

namespace WindowsService.Common
{
    public class TaskManager
    {
        private static Logger logger = Logger.Instance;

        public static void TaskStart()
        {
            ThreadParam threadParam = new ThreadParam();

            // 赋值参数
            threadParam.Tag1 = default(DateTime);
            threadParam.Tag2 = default(int);

            Thread thread = new Thread(new ParameterizedThreadStart(TaskThreadingStart));
            thread.Start(threadParam);
        }

        private static void TaskThreadingStart(object init)
        {
            try
            {
                MyTimer myTimer = new MyTimer();
                myTimer.TimerParam = new TimerParam();

                // 赋值线程传递的参数
                myTimer.ThreadParam = (ThreadParam)init;
                myTimer.TimerParam.Tag1 = default(int);
                myTimer.TimerParam.Tag2 = default(decimal);

                // 初始化 Timer
                myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                // Interval 的单位为 毫秒
                myTimer.Interval = Convert.ToDouble(XmlUtil.GetElementsByTagName("Interval")) * 1000 * 60;
                myTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error("线程运行时发生异常", ex);
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                MyTimer myTimer = (MyTimer)source;

                myTimer.Enabled = false;

                // 执行业务逻辑
                ExecuteAllTasks();

                myTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error("定时器运行时发生异常", ex);
            }
        }

        private static void ExecuteAllTasks()
        {
            // 在此方法中执行业务逻辑
            // TO DO
        }
    }
}
