using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class operate_door : Door_90
     {


          public override void fn_endControl()
          {
               base.fn_endControl();
               StateValueString state = (StateValueString)m_handleEvent.fn_get("onoff");
               if (m_lastTime <= m_closedoffset)
               {
                    if (state == null) return;
                    state.m_date = "off";
                    m_handleEvent.fn_set(state);
               }
               if (m_max - m_lastTime <= m_openoffset)
               {
                    if (state == null) return;
                    state.m_date = "on";
                    m_handleEvent.fn_set(state);
               }
               //m_handleEvent.GetComponent<AB_State>().fn_debugContent();
          }

     } 
}
