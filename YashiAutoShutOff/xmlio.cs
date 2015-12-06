using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace YashiAutoShutOff
{
    class Xmlio
    {
        String xmlName = "";
        XDocument xml;
        public Xmlio(String xmlputh)
        {
            xmlName = xmlputh;
            xml = XDocument.Load(xmlName);
        }

        public string 获得XML值(string 元素, string 属性) //返回值
        {
            //XDocument xmlDoc = XDocument.Load(xmlName);
            //var results = from c in xmlDoc.Descendants(元素)
            //              select c;
            //string s = "";
            //foreach (var result in results)
            //{
            //    s = result.Attribute(属性).Value.ToString();
            //}
            //return s;
            Console.WriteLine(属性);
            return xml.Element("root").Element(属性).Value;
        }

        public void 设置XML值(string 元素, string 属性, string 值)
        {
            //XDocument xmlDoc = XDocument.Load(xmlName);
            //xmlDoc.Element(元素).Attribute(属性).SetValue(值);
            //xmlDoc.Save(xmlName);
            //Console.WriteLine(属性);
            xml.Element("root").Element(属性).SetValue(值);
        }

        public void 保存XML值()
        {
            xml.Save(xmlName);
        }
    }
}
