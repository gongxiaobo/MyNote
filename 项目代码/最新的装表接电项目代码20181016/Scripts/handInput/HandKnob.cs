using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 旋钮的操作类型
     /// </summary>
     public class HandKnob : N_lightTarget
     {
          protected AB_Spanner m_spanner;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_spanner == null)
               {
                    m_spanner = GetComponent<AB_Spanner>();
               }
               if (m_spanner == null)
               {
                    return;
               }
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    m_spanner.fn_startControl(_hand.fni_getHandRigid().transform);
               }
               if (_button == E_buttonIndex.e_triggerUp)
               {
                    m_spanner.fn_endControl();
               }
          }
     }

}