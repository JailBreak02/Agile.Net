using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopGlobal.Common
{
    public class ServiceUtil
    {
        private static IApplicationContext ctx = ContextRegistry.GetContext();

        // 时间戳(验证单例)
        private string _createdTimestamp;
        private static ServiceUtil _instance;
        // Creates an syn object.
        private static readonly object SynObject = new object();

        /// <summary>
        /// 无参数的构造函数
        /// </summary>
        private ServiceUtil()
        {
            _createdTimestamp = DateTime.Now.ToString();
        }

        /// <summary>
        /// 公共单例实例
        /// </summary>
        public static ServiceUtil Instance
        {
            get
            {
                // Double-Checked Locking
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new ServiceUtil();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 获取指定的IOC对象
        /// </summary>
        /// <typeparam name="T">要获取对象的类型</typeparam>
        /// <returns>指定的对象</returns>
        public T GetObject<T>()
            where T : class
        {
            IDictionary<string, T> objects = ctx.GetObjects<T>();
            foreach (T item in objects.Values)
            {
                return (T)item;
            }
            return null;
        }
    }
}
