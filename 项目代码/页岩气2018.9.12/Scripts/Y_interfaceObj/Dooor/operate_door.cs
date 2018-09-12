using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class operate_door : Door_90
     {

          public bool m_flip = false;
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_handleEvent==null)
               {
                    Debug.Log("<color=red>not find m_handleEvent!!</color>");
                    return;
               }
               
               if (m_lastTime <= m_closedoffset)
               {

                    if (m_flip==false)
                    {
                         fnp_setState("off");
                    }
                    else
                    {
                         fnp_setState();
                    }
                    Debug.Log("<color=blue>关闭阀门</color>");
     
               }
               if (m_max - m_lastTime <= m_openoffset)
               {
                    if (m_flip == false)
                    {
                         fnp_setState();
                    }
                    else
                    {
                         fnp_setState("off");
                    }
               }
               //m_handleEvent.GetComponent<AB_State>().fn_debugContent();
          }
          protected void fnp_setState(string _onoff = "on")
          {
               StateValueString state = (StateValueString)m_handleEvent.fn_get("onoff");
               if (state == null) return;
               state.m_date = _onoff;
               m_handleEvent.fn_set(state);
          }

     } 
}
