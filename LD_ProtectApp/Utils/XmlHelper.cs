using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LD_ProtectApp.Utils
{
    public class XmlHelper
    {
        /// <summary>
        /// 根据XML模板与模型类的对应关系
        /// 将XML文档中的数据转化成一个对象集合
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="path">xml文档所在路径</param>
        /// <returns></returns>
        public static List<T> XmlToModel<T>(string path) where T : new()
        {
            List<T> returnData = new List<T>();
            Type tp = typeof(T);
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            // 得到根节点
            XmlNode xn = xmlDoc.SelectSingleNode(tp.Name.ToLower());
            // 得到根节点的所有子节点
            XmlNodeList childNodes = xn.ChildNodes;

            foreach (XmlNode childNode in childNodes)
            {
                T instance = new T();
                //将节点转化成元素从而取得属性值
                XmlElement xe = childNode as XmlElement;
                var properties = tp.GetProperties();
                //通过反射给实例中的属性进行赋值
                foreach (var propertie in properties)
                {
                    string xmlValue = xe.GetAttribute(propertie.Name);
                    propertie.SetValue(instance, xmlValue);
                }
                returnData.Add(instance);
            }

            return returnData;
        }
    }
}
