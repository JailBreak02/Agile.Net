using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsService.Common
{
    public class XmlUtil
    {
        // XML文件路径
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + "XmlSetting.xml";

        // 只读属性
        public static string FilePath
        {
            get
            {
                return filePath;
            }
        }

        /// <summary>
        /// 获取XML结点的值
        /// </summary>
        /// <param name="nodeName">结点名称</param>
        /// <returns></returns>
        public static string GetElementsByTagName(string nodeName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(FilePath);
            XmlNodeList nodes = xmldoc.GetElementsByTagName(nodeName);
            return nodes[0].InnerText;
        }

        /// <summary>
        /// 修改XML结点的值
        /// </summary>
        /// <param name="nodeName">结点名称</param>
        /// <param name="nodeValue">结点的值</param>
        public static void UpdateXMLNode(string nodeName,string nodeValue)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(FilePath);
            XmlNodeList nodes = xmldoc.GetElementsByTagName(nodeName);
            nodes[0].InnerText = nodeValue;
            xmldoc.Save(FilePath);
        }
    }
}
