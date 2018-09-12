using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testButtonOnOff : A_TriggerObj
     {

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_triggerDown)
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
