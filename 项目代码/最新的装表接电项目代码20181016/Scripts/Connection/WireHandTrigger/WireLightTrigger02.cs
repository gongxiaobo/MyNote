using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 移除连线
     /// </summary>
     public class WireLightTrigger02 : WireLightTrigger
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    if (S_selectUI.Instance.m_isDisLine==false)
                    {
                         return;
                    }
                    AB_Wire t_wire = GetComponent<AB_Wire>();
                    if (t_wire!=null)
                    {
                         if (t_wire.IsConnect)
                         {
                              t_wire.fn_clear();
                              t_wire.fn_hide(); 
                         }
                    }
               }
          }

     } 
}
