using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Commands
{
    public class ServiceCommand : ICommand
    {
        #region ICommand Members

        public bool IsUndoCapable
        {
            get { return true; }
        }

        public void Execute()
        {
            Console.Out.WriteLine("--- ServiceCommand implementation : Execute()... ---");
        }

        public void UnExecute()
        {
            Console.Out.WriteLine("--- ServiceCommand implementation : UnExecute()... ---");

            // Uncomment to see IThrowAdvice implementation in action
            //throw new Exception("The method or operation is not supported.");
        }

        #endregion
    }
}
