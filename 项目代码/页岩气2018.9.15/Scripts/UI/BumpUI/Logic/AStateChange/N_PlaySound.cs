using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 泵开启或关闭的声音
     /// </summary>
     public class N_PlaySound : AB_ADo
     {
          /// <summary>
          /// 关注被谁触发的ID
          /// </summary>
          public int m_TriggerFrom = 3143;
         
          public override void fn_ToDo()
          {
               if (m_triggerID == m_TriggerFrom)
               {//泵的开启按钮
                    if (mi_getOtherState.fni_otherState(m_TriggerFrom) == "on")
                    {
                         S_SoundComSingle.Instance.fnp_sound("wind_machine_big");
                    }
                    else
                    {
                         S_SoundComSingle.Instance.fnp_sound("wind_machine_big",false);
                    }

               }
          }
     } 
}
