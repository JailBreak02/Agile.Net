using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Data
{
    /// <summary>
    /// 函数返回结果
    /// </summary>
    /// <typeparam name="T">返回结果类型</typeparam>
    public class ResultInfo<T>
    {

        private bool succeed = true;

        /// <summary>
        /// 函数调用成败标识，出现异常返回false，否则返回true
        /// </summary>
        public bool Succeed
        {
            get { return succeed; }
            set { succeed = value; }
        }

        /// <summary>
        /// 返回值内容
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 如果失败，返回失败原因
        /// </summary>
        public string Message { get; set; }
    }
}
