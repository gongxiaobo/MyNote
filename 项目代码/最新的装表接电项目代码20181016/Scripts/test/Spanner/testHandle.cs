using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testHandle : N_lightTarget
     {


          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               AB_Spanner t_handle = GetComponent<AB_Spanner>();
               if (t_handle != null)
               {
                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         t_handle.fn_startControl(_hand.fni_getHandRigid().transform);
                    }
                    if (_button == E_buttonIndex.e_triggerUp)
                    {
                         t_handle.fn_endControl();
                    }
               }
          }
     }

}