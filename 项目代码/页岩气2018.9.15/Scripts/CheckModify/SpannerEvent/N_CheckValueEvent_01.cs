using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 值到达最大值后的处理
     /// </summary>
     public class N_CheckValueEvent_01 : AB_CheckValueEvent
     {

          public List<GameObject> m_obj = new List<GameObject>();
          public override void fn_ValueEvent(float _now, Vector2 _valuelimit)
          {

               //Debug.Log("<color=blue>blue:</color>" + _now);
     
               if (_now>=_valuelimit.y)
               {
                    if (m_obj.Count>0)
                    {
                         for (int i = 0; i < m_obj.Count; i++)
                         {
                              m_obj[i].SetActive(true);
                         }
                    }
               }
          }
     } 
}
