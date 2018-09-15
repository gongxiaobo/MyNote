using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 虚拟类型零件的初始，显示或者隐藏触发器
     /// </summary>
     public class N_PartTriggerInit_1_3 : N_PartTriggerInit_1
     {
          /// <summary>
          /// 在虚拟零件状态值相同时才能打开触发器
          /// </summary>
          public string m_MainValue = "90";
          protected override void fnp_DoInit()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               AB_State t_state = GetComponent<AB_State>();
               //if (t_state.fn_getMainValue()=="0")
               //{
               //     S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);

               //     Debug.Log("<color=red>S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false)</color>"
               //          + t_name.m_ID);
               //     fnp_setLockState("lock", "unlock");
               //     return;
               //}
               //base.fnp_DoInit();
               //如果前一个零件不再机器里，那么就显示触发器，让用户可以操作
               AB_Condition t_theCondition = GetComponent<AB_Condition>();
               if (t_theCondition != null)
               {//检查条件
                    if (t_theCondition.fn_check("initTrigger")&&
                         t_state.fn_getMainValue() == m_MainValue)
                    {
                         //fnp_setLockState("lock", "unlock");
                         if (t_name != null)
                         {
                              S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, true);
                         }
                         return;
                    }
               }
              
               if (t_name != null)
               {
                    S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);

                    Debug.Log("<color=red>S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false)</color>" 
                         + t_name.m_ID);
     
               }
               //fnp_setLockState("lock", "lock");

          }
        
     } 
}
