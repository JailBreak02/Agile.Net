using AopGlobal.Attributes;
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
    }
}
