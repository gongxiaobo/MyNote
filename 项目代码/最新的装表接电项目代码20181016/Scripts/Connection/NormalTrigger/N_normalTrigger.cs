using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.NormalTrigger
{
     /// <summary>
     /// 处理装表接电模式下普通的操作类型的触发类
     /// </summary>
     class N_normalTrigger :A_TriggerObj
     {
          protected AB_LightOneObj[] m_lights = null;
          protected override void Start()
          {
               base.Start();
               if (m_lights==null)
               {
                    m_lights = GetComponentsInChildren<AB_LightOneObj>();
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button== E_buttonIndex.e_padTouched)
               {
                    fnp_setLight();
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
               if (_button== E_buttonIndex.e_padTouchOver)
               {
                    fnp_setLight(false);
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
          }
          protected virtual void fnp_setLight(bool _light=true)
          {
               if (m_lights==null)
               {
                    return;
               }
               for (int i = 0; i < m_lights.Length; i++)
               {
                    if(_light)
                    m_lights[i].fn_light();
                    else
                    m_lights[i].fn_endLigth();
               }
          }
     }
}
