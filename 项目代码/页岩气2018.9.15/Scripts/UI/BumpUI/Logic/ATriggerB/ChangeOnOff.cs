using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 开关类型的值设定
     /// </summary>
     public class ChangeOnOff : AB_AToB
     {
          /// <summary>
          /// 泵打开后，需要改变的状态值
          /// </summary>
          public string m_state = "on";
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
                    
                         if (m_state == "on")
                         {
                              m_control.fni_on();
                         }
                         else
                         {
                              m_control.fni_off();
                         } 
                    }

               }
          }
     } 
}
