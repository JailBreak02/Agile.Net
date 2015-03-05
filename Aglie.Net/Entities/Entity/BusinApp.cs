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
        /// 交易日期(后台创建)
        /// </summary>
        public virtual DateTime TransactionDate { get { return _transactionData; } set { _transactionData = value.Date; } }

        /// <summary>
        /// 申请日期(后台创建)
        /// </summary>
        public virtual DateTime? AppTime { get; set; }

        /// <summary>
        /// 申请金额(认购/申购必须)
        /// </summary>
        public virtual decimal AppAmount { get; set; }

        /// <summary>
        /// 申请份额(赎回/转换必须)
        /// </summary>
        public virtual decimal? AppVol { get; set; }

        #endregion
    }
}
