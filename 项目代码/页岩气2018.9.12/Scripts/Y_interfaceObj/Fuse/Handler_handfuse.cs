using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Handler_handfuse : N_HandleEvent_init
     {

          public override void fn_HandleMsg(AB_Message _msg)
          {
               base.fn_HandleMsg(_msg);
               if (_msg.Type == E_MessageType.e_outside)
                    m_machineMag.fn_ReceiveEvent(_msg);

          }
     }

}