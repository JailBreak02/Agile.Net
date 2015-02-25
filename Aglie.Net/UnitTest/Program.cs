using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Log4net;
using UnitTest.Spring.Net;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SpringTest.AopTest();
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
