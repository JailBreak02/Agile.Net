using AopGlobal.Commands;
using AopGlobal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Spring.Net
{
    public class SpringTest
    {
        private static ServiceUtil serviceUtil = ServiceUtil.Instance;

        public static void AopTest()
        {
            try
            {
                // Create AOP proxy using Spring.NET IoC container.
                ICommand command = serviceUtil.GetObject<ICommand>();

                command.Execute();
                if (command.IsUndoCapable)
                {
                    command.UnExecute();
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine();
                Console.Out.WriteLine(ex);
            }
            finally
            {
                Console.Out.WriteLine();
                Console.Out.WriteLine("--- hit <return> to quit ---");
                Console.ReadLine();
            }
        }
    }
}
