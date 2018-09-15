using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.Wire;
namespace GasPowerGeneration
{
     /// <summary>
     /// 新的执行拆线操作
     /// </summary>
     public class WireLightTrigger03 : WireLightTrigger
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    if (S_selectUI.Instance.m_isDisLine == false)
                    {
                         return;
                    }
                    
                    //拆线操作
                    AB_RemoveWire t_removeWire = GetComponent<AB_RemoveWire>();
                    if (t_removeWire!=null)
                    {
                         t_removeWire.fn_remove();
                    }

               }
          }
     }
}
