using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class ChangeNumber02 : ChangeNumber
     {
          /// <summary>
          /// off 时的值变化
          /// </summary>
          public float m_Value2;
          public override void fn_ToDo()
          {
               if (m_triggerID == m_TriggerFrom)
               {//泵的开启按钮
                    if (mi_getOtherState.fni_otherState(m_TriggerFrom) == "on")
                    {
                         m_control.fni_level(m_Value1);
                    }
                    else
                    {
                         m_control.fni_level(m_Value2);
                    }

               }
          }

     } 
}
