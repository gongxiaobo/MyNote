using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 添加能激活取出物体的类型
     /// </summary>
     public class N_PullOutHand : N_lightTarget
     {
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               AB_Spanner t_handle = GetComponent<AB_Spanner>();
               AB_PullOut t_pullOut = GetComponent<AB_PullOut>();
               if (t_handle != null)
               {
                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         t_handle.fn_startControl(_hand.fni_getHandRigid().transform);
                         if (t_pullOut!=null)
                         {//激活拉出物体的管理类
                              t_pullOut.fn_activation();
                         }
                    }
                    if (_button == E_buttonIndex.e_triggerUp)
                    {
                         t_handle.fn_endControl();
                    }
               }
          }     
         
     } 
}
