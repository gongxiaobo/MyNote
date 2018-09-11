using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 柱型工具碰触到触发器要做的工作
     /// </summary>
     public class N_PullerTrigger_02 : N_PullerTrigger
     {
          protected override void fnp_Do(GameObject _collider)
          {
               base.fnp_Do(_collider);
               //设置柱子的位置
               AB_ToolInitPos t_toolInitPos = GetComponentInChildren<AB_ToolInitPos>();
               AB_NameFlag t_nf1 = GetComponent<AB_NameFlag>();
               if (t_nf1 != null && t_toolInitPos != null)
               {
                    if (t_nf1.M_nameID == 4030)
                    {
                         t_toolInitPos.fn_setLevelPos(1);
                    }
                    else if (t_nf1.M_nameID== 4031)
                    {
                         t_toolInitPos.fn_setLevelPos(2);
                    }
               }
               //重置倒计时
               AB_ColumnCount t_count = GetComponentInChildren<AB_ColumnCount>();
               if (t_count!=null)
               {
                    t_count.fn_reset();
               }
               //AB_NameFlag t_nf = _collider.GetComponent<AB_NameFlag>();
               if (t_nf1 != null)
               {
                    AB_ToolTriggerInfo t_info =
                         S_ToolTrigger.Instance.fn_getToolTrigger(t_nf1.M_nameID);
                    if (t_info != null)
                    {
                         t_info.fn_HideToolTrigger();
                    }
               }

          }
          
     } 
}
