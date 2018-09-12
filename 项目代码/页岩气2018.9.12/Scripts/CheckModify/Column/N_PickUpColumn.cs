using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 柱形工具的拾取和操作动画控制,倒计时控制组件
     /// </summary>
     public class N_PickUpColumn : N_PickUp
     {
          protected bool m_isTriggered = false;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               //m_rotateControl的值会被在碰触到触发器时就被设置为true，表示现在需要操作工具
               //到一定要求，要求结束后才可以拿出手柄，回到可以拾取的状态。
               if (m_rotateControl)
               {//开始控制手柄的旋转
                    if (m_isTriggered)
                    {
                         return;
                    }
                    m_isTriggered = m_rotateControl;
                    if (!fnp_findHandle())
                    {
                         return;
                    }
                    if (!fnp_findColumnCount())
                    {
                         return;
                    }
                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         //播放手柄动画
                         m_pullerHandle.fn_Trigger("go");
                         m_ColumnCount.fn_StartCount();
                    }
                    

               }
          }
          /// <summary>
          /// 把手动画控制
          /// </summary>
          protected AB_AnimatorControl m_pullerHandle = null;
          /// <summary>
          /// 找到操作的动画组件
          /// </summary>
          /// <returns></returns>
          protected bool fnp_findHandle()
          {
               if (m_pullerHandle == null)
               {
                    m_pullerHandle = GetComponentInChildren<AB_AnimatorControl>();
               }
               return (m_pullerHandle == null) ? false : true;
          }
          /// <summary>
          /// 柱子的倒计时
          /// </summary>
          protected AB_ColumnCount m_ColumnCount = null;
          protected bool fnp_findColumnCount()
          {
               if (m_ColumnCount == null)
               {
                    m_ColumnCount = GetComponentInChildren<AB_ColumnCount>();
               }
               return (m_ColumnCount == null) ? false : true;
          }
     } 
}
