using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
namespace GasPowerGeneration
{

     public class XMLOperation : MonoBehaviour
     {

          /// <summary>
          /// 读取第二语言
          /// </summary>
          public static Language xmlReadSecondLan()
          {
               Language lan;
               XmlDocument xml = new XmlDocument();
               string path = Application.streamingAssetsPath + "/data.xml";
               xml.Load(path);
               XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
               foreach (XmlElement xl1 in xmlNodeList)
               {
                    if (xl1.GetAttribute("name") == "SecondLanguage")
                    {
                         foreach (XmlElement xl2 in xl1.ChildNodes)
                         {
                              if (xl2.GetAttribute("name") == "Lan")
                              {
                                   string temp = xl2.InnerText;
                                   lan = (Language)Enum.Parse(typeof(Language), temp, true);
                                   return lan;
                              }
                         }
                    }
               }
               return Language.Null;
          }
          public static Language xmlReadFirstLan()
          {
               Language lan;
               XmlDocument xml = new XmlDocument();
               string path = Application.streamingAssetsPath + "/data.xml";
               xml.Load(path);
               XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
               foreach (XmlElement xl1 in xmlNodeList)
               {
                    if (xl1.GetAttribute("name") == "FirstLanguage")
                    {
                         foreach (XmlElement xl2 in xl1.ChildNodes)
                         {
                              if (xl2.GetAttribute("name") == "Lan")
                              {
                                   string temp = xl2.InnerText;
                                   lan = (Language)Enum.Parse(typeof(Language), temp, true);
                                   return lan;
                              }
                         }
                    }
               }
               return Language.Null;
          }
     }
     
}