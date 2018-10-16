using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 按钮按下时发送消息
     /// </summary>
     public class N_ropeTrigger01_02 : N_ropeTrigger01
     {
          AB_UILevel01 m_button = null;
          protected override void Start()
          {
               base.Start();
               if (m_button == null)
               {
                    m_button = GetComponent<AB_UILevel01>();
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               //base.fn_trigger(_button, _hand);
               if (m_ropeLight == null)
               {
                    m_ropeLight = GetComponent<AB_ropeLight>();
               }
               if (_button == E_buttonIndex.e_padTouched)
               {
                    if (m_ropeLight != null)
                    {
                         m_ropeLight.fn_highlight();
                    }
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
              
               if (m_button == null)
               {
                    return;
               }
               if (_button == E_buttonIndex.e_padPressDown)
               {//按钮按下

                    m_button.fn_buttonHit();
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    if (m_ropeLight != null &&S_selectUI.Instance.m_isDisLine==false)
                    {
                         m_ropeLight.fn_default();
                    }
               }
          }

     }
}
