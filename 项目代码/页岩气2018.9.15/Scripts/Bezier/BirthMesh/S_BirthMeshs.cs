using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 所有动态生成电线的集合
     /// </summary>
     public class S_BirthMeshs : GenericSingletonClass<S_BirthMeshs>
     {
          Dictionary<string, AB_BirthMesh> m_birthmeshes = new Dictionary<string, AB_BirthMesh>();
          public void fn_add(string _name, AB_BirthMesh _bm)
          {
               if (!m_birthmeshes.ContainsKey(_name))
               {
                    if (_bm!=null)
                    {
                         m_birthmeshes.Add(_name, _bm);
                    }
               }
          }
          public AB_BirthMesh fn_get(string _name)
          {
               if (m_birthmeshes.ContainsKey(_name))
               {
                    return m_birthmeshes[_name];
               }
               return null;
          }
     } 
}
