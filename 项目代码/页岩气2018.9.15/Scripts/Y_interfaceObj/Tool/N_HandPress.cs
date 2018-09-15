using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_HandPress : N_lightTarget
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
               }
               if (_button == E_buttonIndex.e_triggerUp)
               {
                    AB_Spanner t_button = GetComponent<AB_Spanner>();
                    if (t_button != null)
                    {
                         t_button.fn_startControl(null);
                    }
               }

          }
     }

}