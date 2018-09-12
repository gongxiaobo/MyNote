using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 根据一个参数按照一个系数进行变化
     /// </summary>
     public class ChangeNumber01 : ChangeNumber
     {
          public override void fn_ToDo()
          {
               //base.fn_ToDo();
               if (m_triggerID == m_TriggerFrom)
               {//
                    //if (mi_getOtherState.fni_otherState(m_triggerID) == "on")
                    //{
                    //     m_control.fni_level(m_Value1);
                    //}
                    string t_valueFrom = mi_getOtherState.fni_otherState(m_TriggerFrom);
                    float t_vf;
                    if (float.TryParse(t_valueFrom, out t_vf))
                    {
                         m_control.fni_level(m_Value1 * t_vf);
                    }


               }

          }

     } 
}
