using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 泵操作界面的逻辑控制
     /// 被触发后改变状态值到指定值
     /// float 参数类型
     /// </summary>
     public class ChangeNumber : AB_AToB
     {
          /// <summary>
          /// 泵开启后，需要到达的值
          /// </summary>
          public float m_Value1;
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
                         m_control.fni_level(m_Value1); 
                    }

               }
          }
     } 
}
