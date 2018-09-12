using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把在开始位置不能不拔出也就是在0位置
     /// 这个类处理T型工具的拿出问题
     /// 在碰触到零件时就判断在哪里可以拿出手柄
     /// </summary>
     public class N_Yaoba_stateBack_01_01 : N_Yaoba_stateBack_01, I_ToolPullOutLogic
     {
         
          protected override void fnp_PullOutCount()
          {
               AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();

               if (t_spanner.fni_getRotateValue() == m_PulloutPos)
               {
                    base.fnp_PullOutCount();
               }
          }



          #region I_ToolPullOutLogic
          float m_PulloutPos = 0f;
          public void fni_PullOutPos()
          {
               AB_Spanner t_spanner = GetComponentInChildren<AB_Spanner>();
               if (t_spanner.fni_getRotateValue() >= t_spanner.fni_getLimit().y)
               {//在最大值位置
                    m_PulloutPos = t_spanner.fni_getLimit().x;
               }
               else if (t_spanner.fni_getRotateValue() <= t_spanner.fni_getLimit().x)
               {//在最小值位置
                    m_PulloutPos = t_spanner.fni_getLimit().y;
               }
          } 
          #endregion
     } 
}
