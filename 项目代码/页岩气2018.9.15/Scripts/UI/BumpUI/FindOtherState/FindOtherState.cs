using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 找到一个泵下的所有参数
     /// </summary>
     public class FindOtherState : MonoBehaviour, I_getOtherState
     {
          Dictionary<string, AB_HandleEvent> m_handleEvents=null;
          // Use this for initialization
          void Start()
          {
               fnp_findThisState();
          }
          protected void fnp_findThisState()
          {
               if (m_handleEvents==null)
               {
                    m_handleEvents = new Dictionary<string, AB_HandleEvent>();
                    AB_HandleEvent[] t_he = GetComponentsInChildren<AB_HandleEvent>();
                    for (int i = 0; i < t_he.Length; i++)
                    {
                         string t_name = t_he[i].gameObject.name;
                         if (!m_handleEvents.ContainsKey(t_name))
                         {
                              m_handleEvents.Add(t_name, t_he[i]);
                         }
                         else
                         {
                              Debug.Log("<color=red>泵的参数组件下有相同的 id</color>"+t_name);
                         }
                    }
               }
          }


          public string fni_otherState(int _itemID)
          {
               fnp_findThisState();
               string t_id=_itemID.ToString();
               if (m_handleEvents.ContainsKey(t_id))
               {
                    return m_handleEvents[t_id].fn_getMainValue();
               }
               return "";
          }
     }
}
