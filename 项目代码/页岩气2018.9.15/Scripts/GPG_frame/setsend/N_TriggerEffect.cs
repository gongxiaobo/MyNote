using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 使用这个来找到item的效果，使用效果
     /// </summary>
     public class N_TriggerEffect : AB_TriggerEffect
     {

          public override void fn_effect(E_effectType _type, E_effectName _name, AB_Name _itemName)
          {
               if (_itemName == null)
               {
                    return;
               }
               List<AB_effect> t_effects = S_SceneMagT1.Instance.fn_getEffect(_itemName.m_ID);
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
     } 
}
