using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 主要处理旋钮类型在变化值后，触发一些事件
     /// </summary>
     public class CaculateAngelLimitSetRT_2 : CaculateAngelLimitSetRT
     {
          AB_CheckValueEvent[] m_events = null;
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_events==null)
               {
                    m_events = GetComponents<AB_CheckValueEvent>();
               }
               if (m_events!=null)
               {
                    for (int i = 0; i < m_events.Length; i++)
                    {
                         m_events[i].fn_ValueEvent(m_allRotate, m_limitRang);
                    }
               }

          }
          public bool m_RealtimeCheckValueEvent = false;
          protected override void fnp_handleRotate()
          {
               base.fnp_handleRotate();
               if (m_RealtimeCheckValueEvent)
               {
                    if (m_events == null)
                    {
                         m_events = GetComponents<AB_CheckValueEvent>();
                    }
                    if (m_events != null)
                    {
                         for (int i = 0; i < m_events.Length; i++)
                         {
                              m_events[i].fn_ValueEvent(m_allRotate, m_limitRang);
                         }
                    }
               }

          }
         

     } 
}
