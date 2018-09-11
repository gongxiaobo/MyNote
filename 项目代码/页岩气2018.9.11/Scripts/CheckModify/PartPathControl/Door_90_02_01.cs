using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理弹簧盖板的问题，多个因素导致是否打开碰撞器
     /// </summary>
     public class Door_90_02_01 : Door_90_02
     {
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //base.fni_stateChange(_statename, _value, _controlType);
               if (_statename == "lock")
               {//锁定状态的改变
                    I_PullOutTrigger t_pullTrigger = GetComponent<I_PullOutTrigger>();
                    if (_value == "unlock")
                    {//被解锁
                         //这里需要判断条件才能打开触发器，然后才可以操作
                         AB_Condition t_theCondition = GetComponent<AB_Condition>();
                         if (t_theCondition != null)
                         {//检查条件
                              if (t_theCondition.fn_check("initTrigger")==false)
                              {
                                   return;
                              }
                         }
                         fnp_setTrigger(t_pullTrigger);
                    }
                    else
                    {//被加锁
                         fnp_setTrigger(t_pullTrigger, false);
                    }
               }

          }
     } 
}
