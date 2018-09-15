using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// UI的大小改变，当射线碰触时
     /// </summary>
     public class N_ropeTrigger01 : A_TriggerObj
     {

          protected AB_ropeLight m_ropeLight = null;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (m_ropeLight==null)
               {
                    m_ropeLight = GetComponent<AB_ropeLight>();
               }
               if (_button== E_buttonIndex.e_padTouched)
               {
                    if (m_ropeLight!=null)
                    {
                         m_ropeLight.fn_highlight();
                    }
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
               if (_button== E_buttonIndex.e_padTouchOver)
               {
                    if (m_ropeLight != null)
                    {
                         m_ropeLight.fn_default();
                    }
               }
          }
     } 
}
