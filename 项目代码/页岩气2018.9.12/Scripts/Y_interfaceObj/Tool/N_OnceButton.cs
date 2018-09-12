using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_OnceButton : N_lightTarget
     {

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    AB_Spanner t_button = GetComponent<AB_Spanner>();
                    if (t_button != null)
                    {
                         t_button.fn_startControl(null);
                    }
                    CancelInvoke("fn_Cancel_press");
               }
               if (_button == E_buttonIndex.e_triggerUp)
               {
                    Invoke("fn_Cancel_press", 10f);
               }

          }

          private void fn_Cancel_press()
          {
               AB_Spanner t_button = GetComponent<AB_Spanner>();
               if (t_button != null)
               {
                    t_button.fn_startControl(null);

               }
          }
     }

}