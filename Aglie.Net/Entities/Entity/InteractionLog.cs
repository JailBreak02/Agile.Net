using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Entity
{
    public class InteractionLog
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public InteractionLog() { }

        #endregion

        #region Public Properties

        /// <summary>
        /// 日志编号
        /// </summary>
        protected virtual int Id { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public virtual string Arguments { get; set; }

        /// <summary>
        /// 用户操作
        /// </summary>
        public virtual string Operation { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool Succeed { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public virtual string Result { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 调用时间
        /// </summary>
        public virtual DateTime InvokedTime { get; set; }

        /// <summary>
        /// 调用地址
        /// </summary>
        public virtual string InvokedAddress { get; set; }

        /// <summary>
        /// 消耗的时间
        /// </summary>
        public virtual string ElapsedTime { get; set; }

        #endregion
    }
}
