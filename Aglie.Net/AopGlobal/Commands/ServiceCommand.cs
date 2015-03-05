using AopGlobal.Attributes;
using Entities.Data;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Commands
{
    public class ServiceCommand : ICommand
    {
        #region 类成员

        //接口 类成员名称 { get; set; } // 嵌套调用其他类的方法

        #endregion

        #region ICommand Members

        public bool IsUndoCapable
        {
            get { return true; }
        }

        public void Execute()
        {
            Console.Out.WriteLine("--- ServiceCommand implementation : Execute()... ---");

            // 方法内部嵌套方法
            //类成员名称.方法();
        }

        public void UnExecute()
        {
            Console.Out.WriteLine("--- ServiceCommand implementation : UnExecute()... ---");

            // Uncomment to see IThrowAdvice implementation in action
            //throw new Exception("The method or operation is not supported.");
        }

        [AopAttribute]
        public void AnotherExecute()
        {
            Console.Out.WriteLine("--- ServiceCommand implementation : AnotherExecute()... ---");
        }

        #endregion

        #region 反射测试方法

        public decimal GetBasicType(string pString, decimal pDecimal, DateTime pDateTime)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 正常返回
            return decimal.MaxValue;
        }

        public ResultInfo<decimal> GetResultInfoBasicType(string pString, decimal pDecimal, DateTime pDateTime)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 返回 null
            //return null;

            // 正常返回
            return new ResultInfo<decimal> { Result = decimal.MaxValue };
        }

        public Customer GetEntity(BusinApp businApp, string FundCode)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 返回 null
            //return null;

            // 正常返回
            return GetCustomerList().First<Customer>();
        }

        public ResultInfo<Customer> GetResultInfoEntity(BusinApp businApp, string FundCode)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 返回 null
            //return null;

            // ResultInfo.Result 为 null
            //return new ResultInfo<Customer> { Result = null };

            // 正常返回
            return new ResultInfo<Customer> { Result = GetCustomerList().First<Customer>() };
        }

        public IList<Customer> GetList(IList<BusinApp> businApps, string FundCode)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 返回 null
            //return null;

            // 正常返回
            return GetCustomerList();
        }

        public ResultInfo<IList<Customer>> GetResultInfoList(IList<BusinApp> businApps, string FundCode)
        {
            // 方法出现异常
            //throw new Exception("Throw an Exception.");

            // 返回 null
            //return null;

            // ResultInfo.Result 为 null
            //return new ResultInfo<IList<Customer>> { Result = null };

            // 正常返回
            return new ResultInfo<IList<Customer>> { Result = GetCustomerList() };
        }

        #endregion

        #region 私有方法

        private IList<Customer> GetCustomerList()
        {
            return new List<Customer>
            {
                new Customer{CustomerNo="024e3c53054e4809a8ec8e44bba23165", CustomerName=null, OpenTime=new DateTime(2015,3,3), IdEndDate=null},
                new Customer{CustomerNo="128bf0410e604ae3b494bcf51dc1d9e2", CustomerName="富贵花", OpenTime=new DateTime(2015,3,4), IdEndDate=new DateTime(2015,3,5)}
            };
        }

        #endregion
    }
}
