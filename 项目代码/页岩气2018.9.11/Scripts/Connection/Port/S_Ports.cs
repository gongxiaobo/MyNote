using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 所有的连线接口的集合
     /// </summary>
     public class S_Ports : GenericSingletonClass<S_Ports>
     {
          protected Dictionary<string, GameObject> m_allPorts = 
               new Dictionary<string, GameObject>();
          public void fn_login(GameObject _obj)
          {
               if (!m_allPorts.ContainsKey(_obj.name))
               {
                    m_allPorts.Add(_obj.name, _obj);
               }
               else
               {
                    Debug.Log("<color=red>same port name </color>" + _obj.name);
               }
          }
          public GameObject fn_getPort(string _name)
          {
               if (m_allPorts.ContainsKey(_name))
               {
                    return m_allPorts[_name];
               }
               return null;
          }

        
     } 
}
