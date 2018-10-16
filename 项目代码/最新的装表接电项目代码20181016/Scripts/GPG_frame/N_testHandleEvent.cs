using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_testHandleEvent : N_HandleEvent
     {
          public override void fn_init(AB_MachineMag _mag)
          {
               base.fn_init(_mag);

               //AB_State t_state = GetComponent<AB_State>();
               //if (m_state != null)
               //{
               //     StateValue[] t_state = new StateValue[3]{
               //          new StateValueString("xx", "good"),
               //          new StateValueInt("yy", 10),
               //     new StateValueString("onoff", "off")};

               //     m_state.fn_setValue(t_state);
               //}
               fnp_show();


          }
          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);

               switch (_msg.Type)
               {
                    case E_MessageType.e_null:
                         break;
                    case E_MessageType.e_inside:
                         if (_msg.FromID == 101)
                         {


                         }
                         break;
                    case E_MessageType.e_outside:
                         break;
                    case E_MessageType.e_changeState:
                         m_state.fn_setValue(_msg.fn_getMessageValue()[0]);
                         fnp_show();
                         break;
                    default:
                         break;
               }
          }
          public override void fn_SendMsg(AB_Message _send)
          {
               base.fn_SendMsg(_send);
          }
          protected virtual void fnp_show()
          {

               //Debug.Log("<color=blue>blue:</color>" + 
               //     ((StateValueString)m_state.fn_getValue("xx")).m_date);


          }
          public override StateValue fn_get(string _name)
          {
               return m_state.fn_getValue(_name);
          }


     }

}