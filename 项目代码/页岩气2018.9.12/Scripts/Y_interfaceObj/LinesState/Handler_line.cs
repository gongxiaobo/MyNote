using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Handler_line : N_HandleEvent_init
     {


          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);
               if (_msg.Type == E_MessageType.e_outside)
                    m_machineMag.fn_ReceiveEvent(_msg);
               //if (_msg.Name == "check" && _msg.ToId == m_ID.m_ID)
               //{

               //    m_state.fn_setValue(_msg.fn_getContent("check"));
               //}

          }


     } 
}
