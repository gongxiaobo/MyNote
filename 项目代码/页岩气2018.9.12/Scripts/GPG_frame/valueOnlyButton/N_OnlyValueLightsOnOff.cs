using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 多个模型的隐藏和显示
     /// </summary>
     public class N_OnlyValueLightsOnOff : N_OnlyValueLogic
     {
          //是否把开和关对换
          public bool m_isFlip = false;
          protected AB_HideModel[] m_lights = null;
          protected override void fnp_On()
          {
               fnp_controlLight();
          }

          private void fnp_controlLight(bool _ison = true)
          {
               if (m_lights == null)
               {
                    m_lights =  GetComponents<AB_HideModel>(); 
               }
               if (m_lights == null)
               {
                    m_lights = GetComponentsInChildren<AB_HideModel>();
               }
              
               if (m_lights != null)
               {
                    for (int i = 0; i < m_lights.Length; i++)
                    {
                         m_lights[i].fn_hide(m_isFlip ? (!_ison) : _ison);
                    }

               }
               else
               {
                    Debug.Log("<color=red>can not find the indictor light! </color>" + this.gameObject.name);
               }
          }
          protected override void fnp_Off()
          {
               fnp_controlLight(false);
          }

     }

}