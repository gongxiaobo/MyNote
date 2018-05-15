using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// 通用操作接口 响应事件类
     /// </summary>
     public class Bhandlertest : N_HandleEvent_init
     {

          private AB_MachineMag machine_manager;

          public override void fn_init(AB_MachineMag _mag)
          {
               base.fn_init(_mag);
               if (m_state != null)
               {
                    StateValue[] t_state = new StateValue[1]{
               new StateValueBool("onoff", false)};

                    m_state.fn_setValue(t_state);
               }
               machine_manager = GetComponentInParent<AB_MachineMag>();
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
                         m_state.fn_setValue(_msg.fn_getMessageValue()[0]);
                         fnp_show();
                         break;
                    case E_MessageType.e_outside:
                         fn_SendMsg(_msg);
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
               machine_manager.fn_ReceiveEvent(_send);
          }
          protected virtual void fnp_show()
          {

               Debug.Log("<color=blue>blue:</color>" + ((StateValueBool)m_state.fn_getValue("onoff")).m_date);
               bool state = ((StateValueBool)m_state.fn_getValue("onoff")).m_date;
               I_Control control = GetComponent<I_Control>();
               if (state)
                    control.fni_on();
               else
                    control.fni_off();


          }
          public override StateValue fn_get(string _name)
          {
               return m_state.fn_getValue(_name);
          }

     }

}