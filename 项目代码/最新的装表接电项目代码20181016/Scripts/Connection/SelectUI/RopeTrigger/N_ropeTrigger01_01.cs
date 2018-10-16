using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 按钮按下时发送消息
     /// </summary>
     public class N_ropeTrigger01_01 : N_ropeTrigger01
     {
          AB_UILevel01 m_button = null;
          protected override void Start()
          {
               base.Start();
               if (m_button==null)
               {
                    m_button = GetComponent<AB_UILevel01>();
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_button==null)
               {
                    return;
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {//按钮按下

                    m_button.fn_buttonHit();
               }
          }

     } 
}
