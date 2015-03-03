using AopAlliance.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace AopGlobal.Common
{
    public class LogUtil
    {
        // 实体项目命名空间
        private static string entityNamespace = "Entities";

        /// <summary>
        /// 获取客户端调用地址
        /// </summary>
        /// <returns></returns>
        public static string GetInvokedAddress()
        {
            // 获取客户端IP地址
            OperationContext context = OperationContext.Current;

            //获取传进的消息属性
            MessageProperties properties = context.IncomingMessageProperties;

            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            // 获取远程终结点地址
            string address = string.Format("{0}:{1}", endpoint.Address, endpoint.Port);

            return address;
        }

        /// <summary>
        /// 获取调用类和方法名
        /// </summary>
        /// <param name="invocation">方法调用对象</param>
        /// <returns></returns>
        public static string GetOperation(IMethodInvocation invocation)
        {
            // 调用方法类名
            string className = invocation.TargetType.Name;

            //调用方法名
            string methodName = invocation.Method.Name;

            string operation = string.Format("{0}:{1}", className, methodName);

            return operation;
        }

        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <param name="exception">异常对象</param>
        /// <returns></returns>
        public static string GetMessage(object returnValue, bool succeed, Exception exception)
        {
            // 方法执行没有异常 赋值 null
            // 方法执行发生异常 获取异常信息且优先获取 InnerException 信息
            object messageObj = succeed ? null : exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            string message = string.Empty;

            if (messageObj != null)
            {
                message = messageObj.ToString();
            }
            else
            {
                message = "null";
            }

            return message;
        }

        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <param name="piMessage">Message属性信息</param>
        /// <param name="exception">异常对象</param>
        /// <returns></returns>
        public static string GetMessage(object returnValue, bool succeed, PropertyInfo piMessage, Exception exception)
        {
            // 方法执行没有异常 通过反射获取 Message 信息
            // 方法执行发生异常 获取异常信息且优先获取 InnerException 信息
            object messageObj = succeed ? piMessage.GetValue(returnValue, null) : exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            string message = string.Empty;

            if (messageObj != null)
            {
                message = messageObj.ToString();
            }
            else
            {
                message = "null";
            }

            return message;
        }

        /// <summary>
        /// 获取参数列表信息
        /// </summary>
        /// <param name="invocation">方法调用对象</param>
        /// <returns></returns>
        public static string GetArgument(IMethodInvocation invocation)
        {
            // 调用方法参数信息列表
            ParameterInfo[] paramsInfo = invocation.Method.GetParameters();

            // 调用方法参数值列表
            object[] arguments = invocation.Arguments;

            string argument = "";
            for (int index = 0; index < paramsInfo.Length; index++)
            {
                // 获取参数名
                argument += paramsInfo[index].Name + ": ";

                // 判断参数值是否为空
                if (arguments[index] == null)
                {
                    argument += "null; ";
                    continue;
                }
                // 如果参数值是实体项目中的 自定义类型 通过反射获取每个成员的值
                // 如果是 List Dictionary Array 等数据量较大的类型 或 自定义类型则
                // 进入 else 逻辑 可以在方法内部通过 Log4net 的 Debug Level 单独记录日志 
                else if (arguments[index].GetType().Namespace.StartsWith(entityNamespace))
                {
                    argument += string.Format("{{0}}; ", GetEntityInfo(arguments[index]));
                }
                // 基本类型 进入 else 逻辑
                else
                {
                    // 添加参数值
                    argument += arguments[index].ToString() + "; ";
                }
            }
            // 返回参数列表拼接字符串
            return argument.TrimEnd(' ', ';');
        }

        /// <summary>
        /// 获取操作结果信息
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <returns></returns>
        public static string GetResult(object returnValue, bool succeed)
        {
            // 方法执行没有异常 赋值 returnValue
            // 方法执行发生异常 赋值为 null
            object resultObj = succeed ? returnValue : null;

            string result = string.Empty;
            StringBuilder resultStr = new StringBuilder();

            if (resultObj != null && resultObj.GetType().Namespace.StartsWith(entityNamespace))
            {
                resultStr = GetEntityInfo(resultObj);
            }
            else if (resultObj == null)
            {
                resultStr = new StringBuilder("null");
            }
            else
            {
                resultStr = new StringBuilder(resultObj.ToString());
            }

            result = string.Format("{0}: {1}", resultObj.GetType().Name, resultStr);

            return result;
        }

        /// <summary>
        /// 获取操作结果信息
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <param name="piResult">Result属性信息</param>
        /// <returns></returns>
        public static string GetResult(object returnValue, bool succeed, PropertyInfo piResult)
        {
            // 方法执行没有异常 通过反射获取 Result 信息
            // 方法执行发生异常 赋值为 null
            object resultObj = succeed ? piResult.GetValue(returnValue, null) : null;

            string result = string.Empty;
            StringBuilder resultStr = new StringBuilder();

            if (resultObj != null && resultObj.GetType().Namespace.StartsWith(entityNamespace))
            {
                resultStr = GetEntityInfo(resultObj);
            }
            else if (resultObj == null)
            {
                resultStr = new StringBuilder("null");
            }
            else
            {
                resultStr = new StringBuilder(resultObj.ToString());
            }

            result = string.Format("{0}: {1}", piResult.PropertyType.Name, resultStr);

            return result;
        }

        #region 私有方法

        /// <summary>
        /// 通过反射获取实体信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        private static StringBuilder GetEntityInfo(object entity)
        {
            StringBuilder entityInfo = new StringBuilder();

            foreach (var property in entity.GetType().GetProperties())
            {
                entityInfo.AppendFormat("{0}:{1}; ", property.Name, property.GetValue(entity, null));
            }

            return entityInfo;
        }

        #endregion
    }
}
