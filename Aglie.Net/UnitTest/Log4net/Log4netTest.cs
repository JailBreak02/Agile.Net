using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest.Log4net
{
    public class Log4netTest
    {
        private static Logger logger = Logger.Instance;

        public static void LoggingExample()
        {
            // Log an info level message
            logger.Info("Application [ConsoleApp] Start");

            // Log a debug message.
            logger.Debug("This is a debug message");

            try
            {
                Bar();
            }
            catch (Exception ex)
            {
                // Log an error with an exception
                logger.Error("Exception thrown from method Bar", ex);
            }

            logger.Error("Hey this is an error!");

            logger.Warn("Hey this is an warn!");

            // Log an info level message
            logger.Info("Application [ConsoleApp] End");

            Console.Write("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void Bar()
        {
            Goo();
        }

        private static void Foo()
        {
            throw new Exception("This is an Exception");
        }

        private static void Goo()
        {
            try
            {
                Foo();
            }
            catch (Exception ex)
            {
                throw new ArithmeticException("Failed in Goo. Calling Foo. Inner Exception provided", ex);
            }
        }
    }
}
