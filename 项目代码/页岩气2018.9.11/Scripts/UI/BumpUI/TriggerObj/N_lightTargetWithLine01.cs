using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 显示和隐藏bumpui
     /// </summary>
     public class N_lightTargetWithLine01 : N_lightTargetWithLine
     {
          Transform m_uiPOs = null;
          Transform m_UI = null;
          /// <summary>
          /// bumpui是否隐藏，true 显示
          /// </summary>
          bool m_uiShow = false;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_uiPOs==null)
               {
                    m_uiPOs = transform.FindSibling("UIPos");
               }
               if (m_UI==null)
               {
                    m_UI=BumpUI_manager.Instance.gameObject.transform.parent.transform;
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    m_uiShow = !m_uiShow;
                    if (m_uiShow)
                    {//显示
                         m_UI.position = m_uiPOs.position;
                         m_UI.rotation = m_uiPOs.rotation;
                    }
                    else
                    {
                         m_UI.position = m_uiPOs.position - new Vector3(0f, 10f, 0f);
                         m_UI.rotation = Quaternion.identity;
                    }
               }
          }
        
     } 
}
