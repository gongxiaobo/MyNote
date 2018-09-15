using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class Show_button : N_ButtonBase
     {
          //protected AB_effect[] m_effects;
          protected override void Start()
          {
               base.Start();
               //m_effects = GetComponentsInChildren<AB_effect>();
          }
          protected override void fnp_onMessage()
          {
               base.fnp_onMessage();
               StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
               t_value.m_date = "on";
               m_handleEvent.fn_set(t_value);
               //
               fnp_effect(E_effectType.e_on, E_effectName.e_light);
               fnp_effect(E_effectType.e_on, E_effectName.e_sound);
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



     }

}