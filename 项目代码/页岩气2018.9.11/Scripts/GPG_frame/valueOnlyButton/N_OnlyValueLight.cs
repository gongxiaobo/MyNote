using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 灯光类型的交互物体
     /// </summary>
     public class N_OnlyValueLight : N_OnlyValueLogic
     {
          //是否把开和关对换
          public bool m_isFlip = false;
          protected AB_HideModel m_lights = null;
          protected override void Start()
          {
               base.Start();
               //开始找到灯，关闭灯
               fnp_controlLight();
               if (m_lights != null)
               {
                    m_lights.fn_hide(false);
               }
          }
          protected override void fnp_On()
          {

               //Debug.Log("<color=blue>开</color>");

               fnp_controlLight();

               fnp_effect(E_effectType.e_on, E_effectName.e_light);
          }

          private void fnp_controlLight(bool _ison = true)
          {
               m_lights = m_lights ?? GetComponent<AB_HideModel>();
               m_lights = m_lights ?? GetComponentInChildren<AB_HideModel>();
               if (m_lights != null)
               {
                    m_lights.fn_hide(m_isFlip ? (!_ison) : _ison);
               }
               else
               {
                    Debug.Log("<color=red>can not find the indictor light! </color>" + this.gameObject.name);
               }
          }
          protected override void fnp_Off()
          {
               //Debug.Log("<color=blue>关</color>");
               fnp_controlLight(false);
               fnp_effect(E_effectType.e_off, E_effectName.e_light);
          }

     }

}