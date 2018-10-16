using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 控制一个物体的显示和隐藏效果，属于触发效果类
     /// </summary>
     public class N_lightobjOnOff : AB_effect
     {
          protected GameObject m_light = null;
          protected override void Start()
          {
               base.Start();
               m_effectName = E_effectName.e_light;
               if (m_light == null)
               {
                    m_light = this.gameObject;
               }

          }

          public override void fn_effect(E_effectType _type, string _para = "")
          {

               if (_type == E_effectType.e_on)
               {
                    if (m_light != null)
                    {
                         m_light.SetActive(true);
                    }
               }
               else if (_type == E_effectType.e_off)
               {
                    if (m_light != null)
                    {
                         m_light.SetActive(false);

                    }
               }

          }
     }

}