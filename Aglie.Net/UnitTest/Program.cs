using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Log4net;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Log4netTest.LoggingExample();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            finally
            { }
            Console.ReadLine();
        }
    }
}
