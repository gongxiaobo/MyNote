using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 手柄扳机键按下开启，松开扳机键，关闭
     /// </summary>
     public class N_handDownUP : N_handDown
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_triggerUp)
               {
                    AB_Spanner t_button = GetComponent<AB_Spanner>();
                    if (t_button != null)
                    {
                         t_button.fn_startControl(null);
                         t_button.fn_endControl();
                    }
               }
          }
     } 
}
