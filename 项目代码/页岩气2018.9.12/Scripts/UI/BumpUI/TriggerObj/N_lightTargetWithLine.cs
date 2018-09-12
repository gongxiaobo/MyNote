using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 射线高亮一个物体
     /// </summary>
     public class N_lightTargetWithLine : A_TriggerObj
     {
          protected AB_LightOneObj[] t_lights = null;
          /// <summary>
          /// 高亮物体的查找深度值
          /// </summary>
          public byte m_LightOneObjDepth = 0;
         
          private void fnp_light(bool _inOut)
          {
               if (t_lights==null)
               {
                    t_lights = m_LightOneObjDepth == 0 ? GetComponentsInChildren<AB_LightOneObj>() :
                             transform.FindInChlidArray<AB_LightOneObj>(m_LightOneObjDepth); 
               }
               if (t_lights==null)
               {
                    return;
               }
               for (int i = 0; i < t_lights.Length; i++)
               {
                    if (t_lights[i].m_lightObjType == E_LightObjType.e_normal)
                    {
                         if (_inOut)
                         {
                              t_lights[i].fn_light();
                         }
                         else
                         {
                              t_lights[i].fn_endLigth();
                         }
                    }
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button== E_buttonIndex.e_padTouched)
               {
                    fnp_light(true);
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
               if (_button== E_buttonIndex.e_padTouchOver)
               {
                    fnp_light(false);
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
          }

     } 
}
