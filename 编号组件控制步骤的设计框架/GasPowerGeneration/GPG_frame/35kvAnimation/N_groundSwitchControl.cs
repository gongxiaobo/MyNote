using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 35kv 地刀的旋转角度控制
     ///加入地刀的声音
     /// </summary>
     public class N_groundSwitchControl : N_OnlyValueLogic
     {
          protected override void Start()
          {
               base.Start();

          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //base.fni_on(_controlType);
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               //base.fni_off(_controlType);
          }
          float m_lastTime = -1f;
          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {

               float t_valueAni = _level;
               if (m_lastTime == t_valueAni)
               {
                    return;
               }
               m_lastTime = t_valueAni;

               N_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("floatvalue", t_valueAni.ToString(), m_handleEvent);
               //m_handleEvent.fn_debugState();
               //base.fni_level(_level, _controlType);
               if (_controlType == E_ControlType.e_init)
               {

               }
               else
               {
                    if (m_lastTime == 0f)
                    {//分闸
                         fnp_Result("0");
                         //触发效果
                         AB_TriggerEffect t_effect = new N_TriggerEffect();
                         t_effect.fn_effect(E_effectType.e_on, E_effectName.e_sound, m_handleEvent.gameObject.GetComponent<AB_Name>());
                    }
                    if (m_lastTime == 1f)
                    {//合闸
                         fnp_Result("1");
                         //触发效果
                         AB_TriggerEffect t_effect = new N_TriggerEffect();
                         t_effect.fn_effect(E_effectType.e_on, E_effectName.e_sound, m_handleEvent.gameObject.GetComponent<AB_Name>());
                    }
               }

          }
     }

}