using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 旋出旋入类的工具触发器，在碰触到触发器时，根据触发器的类型，调整工具的旋转初始化位置
     /// 在零件旋出前使用范围右值
     /// 在零件旋入前使用范围左值
     /// 这样就保证了左松右紧的规则
     /// </summary>
     public class N_YaobaTrigger_tool01_01 : N_YaobaTrigger_tool01
     {
          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);

               AB_ToolTriggerInfo t_toolTrigger = _collider.GetComponent<AB_ToolTriggerInfo>();
               N_ToolTriggerInfo_01 t_tooltriggerclass = t_toolTrigger as N_ToolTriggerInfo_01;
               if (t_tooltriggerclass != null)
               {
                    AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();
                    AB_RotateRange t_rt = _collider.GetComponent<AB_RotateRange>();
                    
                    if (t_tooltriggerclass.m_triggertype== E_ToolTriggerType.e_useToolFirst)
                    {
                         if (t_spanner != null)
                         {
                              t_spanner.fn_setTo(t_rt.M_getRange.y);
                         }
                    }
                    else if (t_tooltriggerclass.m_triggertype== E_ToolTriggerType.e_useToolEnd)
                    {
                         if (t_spanner != null)
                         {
                              t_spanner.fn_setTo(t_rt.M_getRange.x);
                         }
                    }
               }
               //柱塞放入工具的重置
               I_RestMoveAxisPos t_resetAxis = GetComponentInChildren<I_RestMoveAxisPos>();
               if (t_resetAxis!=null)
               {
                    t_resetAxis.fni_reset();
               }
          }

     }
}
