using AopGlobal.Commands;
using AopGlobal.Common;
using Entities.Data;
using Entities.Entity;
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

                #region 反射测试

                decimal resultA = command.GetBasicType("186a0abfbf474b5aa33c16a91b65089c", decimal.MaxValue, default(DateTime));
                ResultInfo<decimal> resultB = command.GetResultInfoBasicType("186a0abfbf474b5aa33c16a91b65089c", decimal.MaxValue, default(DateTime));
                Customer resultC = command.GetEntity(GetBusinAppList().First<BusinApp>(), "202301");
                ResultInfo<Customer> resultD = command.GetResultInfoEntity(GetBusinAppList().First<BusinApp>(), "202301");
                IList<Customer> resultE = command.GetList(GetBusinAppList(), "202301");
                ResultInfo<IList<Customer>> resultF = command.GetResultInfoList(GetBusinAppList(), "202301");

                #endregion

                #region AOP测试

                command.Execute();
                if (command.IsUndoCapable)
                {
                    command.UnExecute();
                }
                command.AnotherExecute();

                #endregion
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

        #region 私有方法

        private static IList<BusinApp> GetBusinAppList()
        {
            return new List<BusinApp>
            {
                new BusinApp{CustomerNo="18558f1c4c87499096e9ec594f0b888b", TransactionDate = new DateTime(2015,3,3), AppTime = null, AppAmount = decimal.MaxValue, AppVol = null},
                new BusinApp{CustomerNo="0d90213fc3f74c0ea69cecf3d55220be", TransactionDate = new DateTime(2015,3,3), AppTime = new DateTime(2015, 3, 4, 12, 13, 14), AppAmount = decimal.MaxValue, AppVol = decimal.MinusOne},
                new BusinApp{CustomerNo="168154f229a04b1f88b14e93e5c7cbda", TransactionDate = new DateTime(2015,3,3), AppTime = new DateTime(2015, 3, 4, 13, 14, 15), AppAmount = decimal.MaxValue, AppVol = decimal.MinusOne}
            };
        }

        #endregion
    }
}
