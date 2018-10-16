using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.Connection.NormalTrigger
{
     /// <summary>
     /// 表盖类型的操作
     /// </summary>
     class N_normalTrigger_01 : N_normalTrigger
     {
          I_Control mi_control = null;
          protected override void Start()
          {
               base.Start();
               if (mi_control == null)
               {
                    mi_control = GetComponent<I_Control>();
               }
               if (mi_control==null)
               {
                    mi_control = GetComponentInParent<I_Control>();
               }
          }
          string m_localstate = "off";
          public override void fn_trigger(GasPowerGeneration.E_buttonIndex _button, GasPowerGeneration.I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    if (mi_control!=null)
                    {
                         if (m_localstate == "on")
                         {
                              m_localstate = "off";
                              mi_control.fni_off();
                         }
                         else
                         {
                              m_localstate = "on";
                              mi_control.fni_on();
                         }
                    }
               }
          }
     }
}
