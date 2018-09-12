using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 唤出UI的触发
     /// </summary>
     public class N_selectUITrigger : A_TriggerObj
     {

          protected AB_ShowSelectUI m_UI = null;
          protected AB_AniTrigger m_Ani = null;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (m_UI == null)
               {
                    m_UI = GetComponent<AB_ShowSelectUI>();
               }
               if (m_Ani == null)
               {
                    m_Ani = GetComponentInChildren<AB_AniTrigger>();
               }
               if (_button== E_buttonIndex.e_padTouched)
               {
                    if (m_Ani!=null)
                    {
                         m_Ani.fn_setTrigger("start");
                    }
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    if (m_UI!=null)
                    {
                         m_UI.fn_trigger();
                    }
               }
               if (_button== E_buttonIndex.e_padTouchOver)
               {
                    if (m_Ani != null)
                    {
                         m_Ani.fn_setTrigger("end");
                    }
               }
          }
     } 
}
