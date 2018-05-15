using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 提示类型的高亮显示模型，比如管道的高亮显示
     /// </summary>
     public class N_TipsEffect : AB_effect
     {
          /// <summary>
          /// 是否在考试中显示
          /// </summary>
          public bool m_showInTest = true;
          protected AB_HideModel m_models = null;
          public bool m_hideStart = false;
          protected override void Start()
          {
               base.Start();
               m_models = GetComponent<AB_HideModel>();
               if (m_models != null)
               {
                    m_models.fn_hide(m_hideStart);
               }
               //if (S_SceneMessage.Instance.fn_getMode()== E_mode.e_test)
               //{

               //}
          }
          public override void fn_effect(E_effectType _type, string _para = "")
          {
               if (m_models == null || m_showInTest == false)
               {
                    return;
               }
               if (_type == E_effectType.e_on)
               {
                    m_models.fn_hide(true);
               }
               else if (_type == E_effectType.e_off)
               {
                    m_models.fn_hide(false);
               }
          }
     }

}