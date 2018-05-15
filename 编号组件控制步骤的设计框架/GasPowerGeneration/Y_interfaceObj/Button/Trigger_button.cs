using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Trigger_button : A_TriggerObj
     {

          I_Control control;
          private AB_Spanner spaner;
          protected override void Start()
          {
               base.Start();
               control = GetComponent<I_Control>();
               spaner = GetComponent<AB_Spanner>();
          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    control.fni_on();
                    spaner.fn_startControl(null);
               }
          }
     }

}