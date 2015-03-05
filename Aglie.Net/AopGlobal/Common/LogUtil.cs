using AopAlliance.Intercept;
using Entities.Entity;
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
        #region 属性

        // 对外返回类型名称
        private static string resultInfoTypeName = "ResultInfo`1";

        // 只读属性
        public static string ResultInfoTypeName
        {
            get
            {
                return resultInfoTypeName;
            }
        }

        // 实体项目命名空间
        private static string entityNamespace = "Entities";

        // 只读属性
        public static string EntityNameSpace
        {
            get
            {
                return entityNamespace;
            }
        }

        #endregion

        /// <summary>
        /// 获取客户端调用地址
        /// </summary>
        /// <returns></returns>
        public static string GetInvokedAddress()
        {
            string address = string.Empty;

            // 获取客户端IP地址
            OperationContext context = OperationContext.Current;

            if (context != null)
            {
                //获取传进的消息属性
                MessageProperties properties = context.IncomingMessageProperties;

                //获取消息发送的远程终结点IP和端口
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                // 获取远程终结点地址
                address = string.Format("{0}:{1}", endpoint.Address, endpoint.Port);
            }
            else
            {
                address = "null";
            }

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

            string operation = string.Format("{0}.{1}", className, methodName);

            return operation;
        }

        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <param name="exception">异常对象</param>
        /// <returns></returns>
        public static string GetMessage(bool succeed, Exception exception)
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
                else if (arguments[index].GetType().Namespace.StartsWith(EntityNameSpace))
                {
                    argument += string.Format("{0}; ", GetEntityInfo(arguments[index]));
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
        /// <param name="invocation">方法调用对象</param>
        /// <param name="returnValue">返回值</param>
        /// <param name="succeed">调用无异常 true 调用有异常 false</param>
        /// <returns></returns>
        public static string GetResult(IMethodInvocation invocation, object returnValue, bool succeed)
        {
            object resultObj = returnValue;

            string result = string.Empty;
            StringBuilder resultStr = new StringBuilder();

            if (resultObj != null && resultObj.GetType().Namespace.StartsWith(EntityNameSpace))
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

            result = string.Format("{0}: {1}", invocation.Method.ReturnType.Name, resultStr);

            return result;
        }

        /// <summary>
        /// 获取操作结果信息
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="piResult">Result属性信息</param>
        /// <returns></returns>
        public static string GetResult(object returnValue, PropertyInfo piResult)
        {
            object resultObj = piResult.GetValue(returnValue, null);

            string result = string.Empty;
            StringBuilder resultStr = new StringBuilder();

            if (resultObj != null && resultObj.GetType().Namespace.StartsWith(EntityNameSpace))
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

        /// <summary>
        /// 转换日志记录对象的为字符串形式
        /// </summary>
        /// <param name="interactionLog">日志记录</param>
        /// <returns></returns>
        public static string GetInteractionLogInfo(InteractionLog interactionLog)
        {
            StringBuilder interactionLogInfo = new StringBuilder();

            foreach (var property in interactionLog.GetType().GetProperties())
            {
                // 两个 { 或者 } 连写表示单个 
                interactionLogInfo.AppendFormat("{0}: {{{1}}}; ", property.Name, property.GetValue(interactionLog, null) == null ? "null" : property.GetValue(interactionLog, null));
            }

            // 移除字符串尾部的 ' '  ';' 字符
            return interactionLogInfo.ToString().TrimEnd(' ', ';');
        }

        #region 私有方法

        /// <summary>
        /// 通过反射获取实体信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        private static StringBuilder GetEntityInfo(object entity)
        {
            StringBuilder entityInfo = new StringBuilder("{");

            foreach (var property in entity.GetType().GetProperties())
            {
                entityInfo.AppendFormat("{0}: {1}; ", property.Name, property.GetValue(entity, null) == null ? "null" : property.GetValue(entity, null));
            }

            // 移除字符串尾部的 ' '  ';' 字符
            return new StringBuilder(entityInfo.ToString().TrimEnd(' ', ';') + "}");
        }

        #endregion
    }
}
