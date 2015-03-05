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
        /// 客户名称
        /// </summary>
        public virtual string CustomerName { get; set; }

        /// <summary>
        /// 开通时间
        /// </summary>
        public virtual DateTime? OpenTime { get; set; }

        /// <summary>
        /// 证件到期日
        /// </summary>
        public virtual DateTime? IdEndDate { get; set; }

        #endregion
    }
}
