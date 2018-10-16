using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.Multiply
{
     /// <summary>
     /// 查找一个接口是否是可多链接接口
     /// </summary>
     public class S_MultiplyItem : GenericSingletonClass<S_MultiplyItem>
     {
          protected Dictionary<string, string[]> m_multiplys = new Dictionary<string, string[]>();
          public void fn_login(string _name, string[] _others)
          {
               if (!m_multiplys.ContainsKey(_name) && _others != null)
               {
                    m_multiplys.Add(_name, _others);
               }
          }
          public string[] fn_getMultiply(string _name)
          {
               if (m_multiplys.ContainsKey(_name))
               {
                    return m_multiplys[_name];
               }
               return null;
          }
     }
}
