using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把旋转后，手松开就回到0位置
     /// </summary>
     public class N_Yaoba_stateBack : N_Yaoba_state, I_YaobaBackSet
     {
          public bool m_BackToZero = false;
          protected override void fnp_handEndControl()
          {
               base.fnp_handEndControl();
               if (m_spanner != null && m_BackToZero)
               {
                    m_spanner.fn_setTo(0f);
               }
          }

          public void fni_setCanBack(bool _iscan)
          {
               m_BackToZero = _iscan;
          }
          /// <summary>
          /// 拔出工具
          /// 0在地上，1在手上，2在机器上
          /// </summary>
          protected override void fnp_Pull()
          {
               base.fnp_Pull();
               //在工具拿出时寻找子物体的接口，这个接口是拿出零件的触发器打开
               I_PullOutPart t_pullout=GetComponentInChildren<I_PullOutPart>();
               if (t_pullout!=null)
               {
                    t_pullout.fni_setTrigger(true);
               }
               else
               {

                    Debug.Log("<color=red>####not find I_PullOutPart</color>");
     
               }
          }
     } 
}
