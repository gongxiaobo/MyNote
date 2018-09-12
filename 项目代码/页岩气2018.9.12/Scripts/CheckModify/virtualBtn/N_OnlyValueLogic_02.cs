using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 
     /// </summary>
     public class N_OnlyValueLogic_02 : N_OnlyValueLogic
     {
          protected override void fnp_On()
          {
               base.fnp_On();

          }
          protected override void fnp_Off()
          {
               base.fnp_Off();
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               AB_Name t_name = GetComponent<AB_Name>();
               AB_State t_state = GetComponent<AB_State>();
               //如果前一个零件不再机器里，那么就显示触发器，让用户可以操作
               AB_Condition t_theCondition = GetComponent<AB_Condition>();
               
               if (_statename == "lock")
               {//锁定状态的改变

                    if (_value == "unlock")
                    {//被解锁

                         if (t_theCondition != null)
                         {//检查条件
                              if (t_theCondition.fn_check("initTrigger"))
                              {
                                   //fnp_setLockState("lock", "unlock");
                                   if (t_name != null)
                                   {
                                        S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, true);
                                   }
                                   //return;
                              }
                         }
                    }
                    else
                    {//被加锁
                         if (t_name != null)
                         {
                              S_ToolTrigger.Instance.fn_SetToolTrigger(t_name.m_ID, false);
                         }
                    }
               }

          }
        
     } 
}
