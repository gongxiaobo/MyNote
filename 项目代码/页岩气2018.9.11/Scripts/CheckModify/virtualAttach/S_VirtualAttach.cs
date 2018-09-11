using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 依附虚拟零件的集合归类
     /// </summary>
     public class S_VirtualAttach : GenericSingletonClass<S_VirtualAttach>
     {
          protected Dictionary<int, AB_VirtualAttach> m_VirtualAttaches =
               new Dictionary<int, AB_VirtualAttach>();
          public void fn_login(int _VirtualID, AB_VirtualAttach _VirtualAttach)
          {
               if (!m_VirtualAttaches.ContainsKey(_VirtualID)&&
                    (_VirtualAttach!=null))
               {
                    m_VirtualAttaches.Add(_VirtualID, _VirtualAttach);
               }
          }
          public void fn_InitAllVirtual()
          {
               if (m_VirtualAttaches.Count>0)
               {
                    foreach (AB_VirtualAttach _attach in m_VirtualAttaches.Values)
                    {
                         _attach.fn_init();
                    }
               }
          }
     } 
}
