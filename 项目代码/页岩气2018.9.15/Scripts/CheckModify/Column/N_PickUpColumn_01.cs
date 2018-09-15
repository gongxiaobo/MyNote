using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拿出柱型工具的功能
     /// </summary>
     public class N_PickUpColumn_01 : N_PickUpColumn
     {

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_rotateControl)
               {//开始控制手柄的旋转


                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         if (m_isCountDown)
                         {
                              m_countdownUI.fn_endCountDown();
                              CancelInvoke("fnp_Pull");
                              m_isCountDown = false;
                         }
                    }
                    

               }
          }
          public override void fn_handInOut(bool _inOut)
          {

               base.fn_handInOut(_inOut);
               if (m_rotateControl == false)
               {
                    return;
               }
               if (!fnp_findCountDown())
               {
                    return;
               }
              
               fnp_StartPullOutTool(_inOut);
          }
          /// <summary>
          /// 开始取下阀座拉出器工具
          /// </summary>
          /// <param name="_inOut"></param>
          protected virtual void fnp_StartPullOutTool(bool _inOut)
          {
               fnp_findColumnCount();
               //fnp_findSpanner();
               if (_inOut && m_rotateControl && (m_ColumnCount.fn_IsEndCount()))
               {//手再次碰触到,当柱子上升到最大值时，可以拿出手柄
                    fnp_PullOutCount();

               }
               else
               {
                    if (m_isCountDown)
                    {
                         m_countdownUI.fn_endCountDown();
                         CancelInvoke("fnp_Pull");
                         m_isCountDown = false;
                    }
               }
          }

          /// <summary>
          /// 拿出摇把的倒计时开始
          /// </summary>
          protected virtual void fnp_PullOutCount()
          {
               if (m_isCountDown)
               {
                    return;
               }
               m_isCountDown = true;
               Invoke("fnp_Pull", 2f);
               m_countdownUI.fn_startCountDown(2f);
          }
          //倒计时组件
          AB_CountDown m_countdownUI = null;
          protected bool fnp_findCountDown()
          {
               //if (m_countdownUI == null)
               {
                    m_countdownUI = GetComponentInChildren<AB_CountDown>();
               }
               return (m_countdownUI == null) ? false : true;
          }
          protected bool m_isCountDown = false;
          //protected AB_Spanner m_spanner;
          //protected bool fnp_findSpanner()
          //{
          //     if (m_spanner == null)
          //     {
          //          m_spanner = GetComponentInChildren<AB_Spanner>();
          //     }
          //     return (m_spanner == null) ? false : true;
          //}
          //public bool m_PullOutBackToZero = false;
          /// <summary>
          /// 拔出工具
          /// </summary>
          protected virtual void fnp_Pull()
          {
               //m_spanner.fn_endControl();
               m_rotateControl = false;
               m_isTriggered = m_rotateControl;
               m_isCountDown = false;
               //m_rotateControl = false;
               Rigidbody t_rg = GetComponent<Rigidbody>();


               AB_YaobaTrigger t_yaobaTrigger = GetComponent<AB_YaobaTrigger>();
               if (t_yaobaTrigger != null)
               {
                    t_yaobaTrigger.fnp_reset();
               }
               AB_NameFlag t_name = GetComponent<AB_NameFlag>();
               if (t_name != null)
               {
                    t_name.M_nameID = 0;
               }
               //如果有音效的，去掉音效名称
               I_setRotateSound t_setRotateSound = GetComponentInChildren<I_setRotateSound>();
               if (t_setRotateSound != null)
               {
                    t_setRotateSound.fni_SetSoundName("");
               }
               Invoke("fnp_wakeCollider", 1.5f);
               if (t_rg != null)
               {
                    t_rg.isKinematic = false;
               }
               FixedJoint t_fj = gameObject.AddComponent<FixedJoint>();
               t_fj.connectedBody = mi_hand.fni_getHandRigid();
               //if (m_PullOutBackToZero)
               //{
               //     m_spanner.fn_setTo(0f);
               //}

               AB_activeTrigger t_at = GetComponentInChildren<AB_activeTrigger>();
               if (t_at != null)
               {
                    t_at.fn_setTrigger();
               }
               else
               {
                    t_at = GetComponent<AB_activeTrigger>();
                    if (t_at != null)
                    {
                         t_at.fn_setTrigger();
                    }
               }
               //m_countdownUI = null;

               //找到工具下链接的零件，打开碰撞体

          }
          protected void fnp_wakeCollider()
          {

          }
     } 
}
