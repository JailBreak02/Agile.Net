using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Commands
{
    public interface ICommand
    {
        bool IsUndoCapable { get; }

        void Execute();

        void UnExecute();
    }
}
