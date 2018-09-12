using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 接线模式的使用射线连线的测试
     /// </summary>
     public class test_connect:A_TriggerObj
     {
          protected test_ChangeMat m_change = null;
          protected test_conMag m_mag = null;
          protected override void Start()
          {
               base.Start();
               m_change = GetComponent<test_ChangeMat>();
               m_mag = this.transform.parent.GetComponent<test_conMag>();
          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               fnp_rayHitChangeColor(_button);
               //if (_button== E_buttonIndex.e_padPressUp)
               //{
                   
               //}
               //if (_button== E_buttonIndex.e_padPressDown)
               //{
               //     fnp_rayHitChangeColor(_button);
               //}
          }
          protected void fnp_rayHitChangeColor(E_buttonIndex _mode)
          {

               if (_mode== E_buttonIndex.e_padTouched)
               {
                    m_change.fn_TouchColorChange(true);
               }
               if (_mode== E_buttonIndex.e_padTouchOver)
               {
                    m_change.fn_TouchColorChange(false);
               }
               //if (_mode == E_buttonIndex.e_padPressUp)
               //{
               //     //fnp_rayHitChangeColor(_button);
               //     m_mr.material = m_default;
               //}
               if (_mode == E_buttonIndex.e_padPressDown)
               {
                    m_change.fn_light();
                    m_mag.fn_Select(this.gameObject);
                   
               }
          }
     } 
}
