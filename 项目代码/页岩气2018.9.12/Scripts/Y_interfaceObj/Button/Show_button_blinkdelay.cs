using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace GasPowerGeneration
{
     public class Show_button_blinkdelay : N_ButtonBase
     {

          //protected AB_effect[] m_effects;
          protected override void Start()
          {
               base.Start();
               //m_effects = GetComponentsInChildren<AB_effect>();
          }
          protected override void fnp_onMessage()
          {
               fnp_effect(E_effectType.e_on, E_effectName.e_sound);
               StartCoroutine(fn_effect_blink());
          }

          void fn_light_on()
          {
               fnp_effect(E_effectType.e_on, E_effectName.e_light);
               StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
               t_value.m_date = "on";
               m_handleEvent.fn_set(t_value);

               fnp_onoffSound("btn_down");
               //产生结果
               fnp_Result("on");

               StopCoroutine(fn_effect_blink());
          }

          protected override void fnp_effect(E_effectType _type, E_effectName _name)
          {
               base.fnp_effect(_type, _name);
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name == null)
               {
                    return;
               }
               List<AB_effect> t_effects = S_SceneMagT1.Instance.fn_getEffect(t_name.m_ID);
               if (t_effects != null)
               {
                    for (int i = 0; i < t_effects.Count; i++)
                    {
                         if (t_effects[i].m_effectName == _name)
                         {
                              t_effects[i].fn_effect(_type, "");
                         }
                    }
               }
          }


          protected override void fnp_offMessage()
          {
               base.fnp_offMessage();
               StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
               t_value.m_date = "off";
               m_handleEvent.fn_set(t_value);
               fnp_effect(E_effectType.e_off, E_effectName.e_light);
               fnp_effect(E_effectType.e_off, E_effectName.e_sound);
          }

          IEnumerator fn_effect_blink()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name == null)
               {
                    yield return null;
               }
               AB_effect t_effect = S_SceneMagT1.Instance.fn_getEffect(t_name.m_ID).First(t => t.m_effectName == E_effectName.e_light);
               t_effect.GetComponent<ParticleSystem>().startLifetime = 0.5f;
               yield return new WaitForSeconds(3f);
               t_effect.GetComponent<ParticleSystem>().startLifetime = 1f;

               fn_light_on();
          }
     }

}