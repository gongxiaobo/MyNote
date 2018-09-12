using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class Handler_button : N_HandleEvent_init
     {


          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);
               if (_msg.Type == E_MessageType.e_outside)
               {
                    print("发送消息外部");
                    fn_SendMsg(_msg);
               }
          }
          public void fnp_show()
          {

               //  Debug.Log("<color=blue>blue:</color>" + ((StateValueBool)m_state.fn_getValue("onoff")).m_date);
               string state = ((StateValueString)m_state.fn_getValue("onoff")).m_date;
               I_Control control = GetComponent<I_Control>();
               control.fni_txt(state);


          }
     } 
}
