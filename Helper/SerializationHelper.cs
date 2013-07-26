using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Helper
{
    /// <summary>
    /// 对象系列化帮助类
    /// </summary>
    public class SerializationHelper
    {
        private SerializationHelper() { }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                // open the stream...
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// 从XML字符串系列化一个对象
        /// </summary>
        /// <param name="type">要系列化的类型</param>
        /// <param name="xmlStr">要系列化的XML</param>
        /// <returns></returns>
        public static object DeserializeString(Type type, string xmlStr)
        {
            System.IO.StringReader strReader = new StringReader(xmlStr);
            XmlSerializer serializer = new XmlSerializer(type);
            return serializer.Deserialize(strReader);
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            // serialize it...
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// 将对象系列化成字符串
        /// </summary>
        /// <param name="obj"></param>
        public static string GetSerializationString(object obj)
        {
            StringBuilder t = new StringBuilder();
            StringWriter w = new StringWriter(t);
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(w, obj);
                return t.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                    w.Dispose();
                }
            }
        }
        /// <summary>
        /// 系列化对象，返回XML文档
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static XmlDocument GetSerializationXml(object obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(SerializationHelper.GetSerializationString(obj));
            ((XmlDeclaration)xmlDoc.FirstChild).Encoding = Encoding.UTF8.BodyName;
            return xmlDoc;
        }
    }
}
