using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_ButtonOnOffWithState : N_ButtonBase
     {

          protected override void fnp_onMessage()
          {
               base.fnp_onMessage();
               StateValue t_sv = m_handleEvent.fn_get("onoff");
               if (t_sv != null)
               {
                    StateValueString t_s = t_sv as StateValueString;
                    t_s.m_date = "on";
                    m_handleEvent.fn_set(t_s);
                    //fnp_Result("on");
               }
               m_handleEvent.fn_debugState();
          }
          protected override void fnp_offMessage()
          {
               base.fnp_offMessage();
               StateValue t_sv = m_handleEvent.fn_get("onoff");
               if (t_sv != null)
               {
                    StateValueString t_s = t_sv as StateValueString;
                    t_s.m_date = "off";
                    m_handleEvent.fn_set(t_s);
                    //fnp_Result("on");
               }
               m_handleEvent.fn_debugState();
          }

     }

}