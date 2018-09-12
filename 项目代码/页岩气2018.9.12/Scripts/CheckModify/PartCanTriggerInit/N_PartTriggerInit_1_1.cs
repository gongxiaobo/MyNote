using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理使用工具的零件的初始化锁定问题
     /// </summary>
     public class N_PartTriggerInit_1_1 : N_PartTriggerInit_1
     {
         
          /// <summary>
          /// 使用工具类型的零件，只需要关闭不再零件上的触发器即可
          /// </summary>
          protected override void fnp_DoInit()
          {
               //base.fnp_DoInit();
               fnp_setLockState("lock", "lock");
               //需要关闭工具的触发器，关闭后不响应工具的触发
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name != null)
               {
                    S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
               }
               else
               {

                    Debug.Log("<color=red>not find AB_Name!</color>");

               }
          }
         
     } 
}
