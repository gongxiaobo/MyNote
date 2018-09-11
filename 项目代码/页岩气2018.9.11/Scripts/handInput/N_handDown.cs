using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 手柄碰到可以操作物体会找物体上的高亮显示模型
     /// </summary>
     public class N_handDown : N_lightTarget
     {
          //protected AB_Spanner t_button = null;
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
