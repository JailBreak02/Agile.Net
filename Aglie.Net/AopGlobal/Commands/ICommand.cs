using Entities.Data;
using Entities.Entity;
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

        void AnotherExecute();

        decimal GetBasicType(string pString, decimal pDecimal, DateTime pDateTime);

        ResultInfo<decimal> GetResultInfoBasicType(string pString, decimal pDecimal, DateTime pDateTime);

        Customer GetEntity(BusinApp businApp, string FundCode);

        ResultInfo<Customer> GetResultInfoEntity(BusinApp businApp, string FundCode);

        IList<Customer> GetList(IList<BusinApp> businApps, string FundCode);

        ResultInfo<IList<Customer>> GetResultInfoList(IList<BusinApp> businApps, string FundCode);
    }
}
