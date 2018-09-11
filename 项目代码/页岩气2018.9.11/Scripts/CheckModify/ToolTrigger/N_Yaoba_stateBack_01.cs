using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 主要解决工具拿出的条件
     /// </summary>
     public class N_Yaoba_stateBack_01 : N_Yaoba_stateBack
     {
          protected override void fnp_PullOutCount()
          {
               //捶打器是否捶打到最末端
               AB_MoveAxis t_moveaxis = GetComponentInChildren<AB_MoveAxis>();
               if (t_moveaxis!=null)
               {
                    Debug.Log("<color=blue>捶打器是否捶打到最末端</color>");
     
                    if (t_moveaxis.m_isReachEnd)
                    {
                         base.fnp_PullOutCount();
                    }
               }
               else { base.fnp_PullOutCount(); }
               
          }

     } 
}
