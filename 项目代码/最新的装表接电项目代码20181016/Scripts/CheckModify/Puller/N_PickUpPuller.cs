using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拉出器的拾取功能类
     /// </summary>
     public class N_PickUpPuller : N_PickUp
     {
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (_inOut==false)
               {
                    //if (m_rotateControl)
                    //{//开始控制手柄的旋转

                    //     if (!fnp_findHandle())
                    //     {
                    //          return;
                    //     }
                    //     if (!fnp_findAniAdd())
                    //     {
                    //          return;
                    //     }
                        
                    //          //停止播放手柄动画
                    //          m_pullerHandle.fn_Trigger("off");
                             

                    //}
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               //m_rotateControl的值会被在碰触到触发器时就被设置为true，表示现在需要操作工具
               //到一定要求，要求结束后才可以拿出手柄，回到可以拾取的状态。
               if (m_rotateControl)
               {//开始控制手柄的旋转

                    if ( !fnp_findHandle())
                    {
                         return;
                    }
                    if (!fnp_findAniAdd())
                    {
                         return;
                    }
                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         //播放手柄动画
                         m_pullerHandle.fn_Trigger("on");
                         //柱子开始向上移动
                         m_animationAdd.fn_StartAddAni();
                    }
                    if (_button == E_buttonIndex.e_triggerUp)
                    {
                         //停止播放手柄动画
                         m_pullerHandle.fn_Trigger("off");
                         ///柱子停止移动
                         m_animationAdd.fn_EndAddAni();
                         //fnp_handEndControl();
                         ////结束检查，关闭发送值通道
                         //m_checkSendMsg.fn_endCheck();
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
               if (m_pullerHandle==null)
               {
                    m_pullerHandle = GetComponentInChildren<AB_AnimatorControl>();
               }
               return (m_pullerHandle == null) ? false : true;
          }
          /// <summary>
          /// 柱子的移动控制
          /// </summary>
          protected AB_AnimationAdd m_animationAdd = null;
          protected bool fnp_findAniAdd()
          {
               if (m_animationAdd==null)
               {
                    m_animationAdd = GetComponentInChildren<AB_AnimationAdd>();
               }
               return (m_animationAdd == null) ? false : true;
          }
        
     } 
}
