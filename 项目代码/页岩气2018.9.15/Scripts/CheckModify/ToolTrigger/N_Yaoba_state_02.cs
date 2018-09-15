using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 处理工具放入零件后，取下工具时，结束对零件的控制
     /// </summary>
     public class N_Yaoba_state_02 : N_Yaoba_state
     {
          protected override void fnp_Pull()
          {
               AB_NameFlag t_name = GetComponent<AB_NameFlag>();
               if (t_name != null)
               {//找到控制零件的控制器,断开工具和零件的控制
                    AB_PullOut t_pullout = S_PullOutPart.Instance.fn_getPullOut(t_name.M_nameID);
                    if (t_pullout!=null)
                    {
                         //I_SetPullBack t_setpullback = t_pullout.gameObject.GetComponent<I_SetPullBack>();
                         //if (t_setpullback!=null)
                         //{
                         //     t_setpullback.fni_setPullBack(true);
                         //}
                         //AB_Spanner t_partControl = t_pullout.gameObject.GetComponent<AB_Spanner>();
                         //if (t_partControl!=null)
                         //{
                         //     t_partControl.fn_endControl();
                         //}
                    }
               }
               base.fnp_Pull();
               //AB_MoveAxis t_moveaxis = GetComponentInChildren<AB_MoveAxis>();
               //if (t_moveaxis!=null)
               //{
               //     t_moveaxis.fn_reset();
               //}
          }

     }
}
