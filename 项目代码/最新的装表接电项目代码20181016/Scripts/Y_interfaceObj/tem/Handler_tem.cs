using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Handler_tem : N_HandleEvent_init
     {

          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);
               //if (_msg.Name == "check" && _msg.ToId == m_ID.m_ID)
               //{

               //    m_state.fn_setValue(_msg.fn_getContent("check"));
               //    m_state.fn_debugContent();
               //}
          }

          public void fnp_show()
          {

               //  Debug.Log("<color=blue>blue:</color>" + ((StateValueBool)m_state.fn_getValue("onoff")).m_date);
               string state = ((StateValueString)m_state.fn_getValue("floatvalue")).m_date;
               I_Control control = GetComponent<I_Control>();
               control.fni_txt(state);


          }
     }

}