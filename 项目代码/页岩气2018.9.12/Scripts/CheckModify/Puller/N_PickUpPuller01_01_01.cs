using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 阀座拉出器的拉出条件判断
     /// 主要是下方阀座拉出器需要先拉出零件，才能取下工具的逻辑
     /// </summary>
     public class N_PickUpPuller01_01_01 : N_PickUpPuller01_01
     {
          protected override void fnp_StartPullOutTool(bool _inOut)
          {
               //这里需要判断条件才能打开触发器，然后才可以操作
               AB_Condition t_theCondition = GetComponent<AB_Condition>();
               if (t_theCondition != null)
               {//检查条件
                    AB_NameFlag t_name = GetComponent<AB_NameFlag>();
                    if (t_name.M_nameID== 4014)
                    {
                         if (t_theCondition.fn_check(t_name.M_nameID.ToString()) == false)
                         {
                              return;
                         }
                         base.fnp_StartPullOutTool(_inOut);
                    }
                    else
                    {
                         base.fnp_StartPullOutTool(_inOut);
                    }
               }
               else
               {
                    base.fnp_StartPullOutTool(_inOut);
               }
               
          }

     } 
}
