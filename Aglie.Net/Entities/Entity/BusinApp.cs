using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Entity
{
    public class BusinApp
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public BusinApp() { }

        #endregion

        private DateTime _transactionData;

        #region Public Properties

        /// <summary>
        /// 申请单号(后台创建)
        /// </summary>
        public virtual string AppSheetSerialNo { get; set; }

        /// <summary>
        /// 客户编号(交易必须)
        /// </summary>
        public virtual string CustomerNo { get; set; }

        /// <summary>
        /// 资产账户编号(交易必须)
        /// </summary>
        public virtual string DepositAccountNo { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        public virtual string BankCode { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public virtual string BankCardNo { get; set; }

        /// <summary>
        /// 上级申请单号(后台创建)
        /// </summary>
        public virtual string ParentAppSheetSerialNo { get; set; }

        /// <summary>
        /// 上级交易类型
        /// </summary>
        public virtual string ParentBusinType { get; set; }

        /// <summary>
        /// FundCode(交易必须)
        /// </summary>
        public virtual string FundCode { get; set; }

        /// <summary>
        /// 交易类型(交易必须)
        /// </summary>
        public virtual string BusinType { get; set; }

        /// <summary>
        /// 交易日期(后台创建)
        /// </summary>
        public virtual DateTime TransactionDate { get { return _transactionData; } set { _transactionData = value.Date; } }

        /// <summary>
        /// 申请日期(后台创建)
        /// </summary>
        public virtual DateTime AppTime { get; set; }

        /// <summary>
        /// 申请金额(认购/申购必须)
        /// </summary>
        public virtual decimal AppAmount { get; set; }

        /// <summary>
        /// 申请份额(赎回/转换必须)
        /// </summary>
        public virtual decimal AppVol { get; set; }

        /// <summary>
        /// 基金收费类型
        /// </summary>
        public virtual string ChargeType { get; set; }

        /// <summary>
        /// 大额赎回标志(赎回必须)
        /// </summary>
        public virtual string LargeRedemptionFlag { get; set; }

        /// <summary>
        /// 分红方式(分红必须)
        /// </summary>
        public virtual string DividendMethod { get; set; }

        /// <summary>
        /// 转换基金代码(转换必须)
        /// </summary>
        public virtual string ObjectFundCode { get; set; }

        /// <summary>
        /// 基金风险(认/申购/转换 必须，转换交易时该属性为目标基金的基金风险)
        /// </summary>
        public virtual string FundRisk { get; set; }

        /// <summary>
        /// 客户风险(认/申购/转换 必须)
        /// </summary>
        public virtual string CustomerRisk { get; set; }

        /// <summary>
        /// 对方销售人代码
        /// </summary>
        public virtual string TargetDistributorCode { get; set; }

        /// <summary>
        /// 原申请单编号
        /// </summary>
        public virtual string OriginalAppSheetNo { get; set; }

        /// <summary>
        /// 申请状态(后台创建)
        /// </summary>
        public virtual string AppState { get; set; }

        /// <summary>
        /// 恒生合同号(后台创建维护)
        /// </summary>
        public virtual string HsSerialNo { get; set; }

        /// <summary>
        /// 恒生申请单号(后台创建维护)
        /// </summary>
        public virtual string HsSheetSerialNo { get; set; }

        /// <summary>
        /// 确认返回码
        /// </summary>
        public virtual string ReturnCode { get; set; }

        /// <summary>
        /// 确认信息
        /// </summary>
        public virtual string CfmResult { get; set; }

        /// <summary>
        /// 恒生错误号
        /// </summary>
        public virtual string HsErrorMsg { get; set; }

        /// <summary>
        /// 调用来源
        /// </summary>
        public virtual string Reference { get; set; }

        /// <summary>
        /// 验证状态
        /// </summary>
        public virtual string CheckState { get; set; }

        #endregion
    }
}
