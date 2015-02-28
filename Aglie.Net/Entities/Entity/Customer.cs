using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Entity
{
    public class Customer
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public Customer() { }

        #endregion

        #region Public Properties

        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual string CustomerNo { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual string HsCustomerNo { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string CustomerName { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public virtual string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public virtual string CertificateNo { get; set; }

        /// <summary>
        /// 资金账号
        /// </summary>
        public virtual string DepositAccountNo { get; set; }

        /// <summary>
        /// 风险等级
        /// </summary>
        public virtual string Risk { get; set; }

        /// <summary>
        /// 风险等级名称
        /// </summary>
        public virtual string RiskName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// 开通时间
        /// </summary>
        public virtual DateTime? OpenTime { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        public virtual DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 证件到期日
        /// </summary>
        public virtual DateTime? IdEndDate { get; set; }

        /// <summary>
        /// 加密证件号码
        /// </summary>
        public virtual string CertificateNoCrypt { get; set; }

        /// <summary>
        /// 查询密码
        /// </summary>
        public virtual string SearchPassword { get; set; }

        #endregion
    }
}
