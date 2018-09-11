using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Item_Handler : N_HandleEvent_init
     {
          protected AB_MachineMag machine_manager;
          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);

               //switch (_msg.Type)
               //{
               //    case E_MessageType.e_null:
               //        break;
               //    case E_MessageType.e_inside:
               //        m_state.fn_setValue(_msg.fn_getMessageValue()[0]);

               //        //fnp_show();
               //        break;
               //    case E_MessageType.e_outside:
               //        fn_SendMsg(_msg);
               //        break;
               //    case E_MessageType.e_changeState:
               //        m_state.fn_setValue(_msg.fn_getMessageValue()[0]);
               //        fnp_show();
               //        break;
               //    default:
               //        break;
               //}
          }
          protected virtual void fnp_show()
          { }
          public override void fn_SendMsg(AB_Message _send)
          {
               base.fn_SendMsg(_send);
               machine_manager.fn_ReceiveEvent(_send);
          }
          public override StateValue fn_get(string _name)
          {
               return m_state.fn_getValue(_name);
          }
     }

}