using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_Yaoba : N_PickUp
     {
          //倒计时组件
          AB_CountDown m_countdownUI;
          protected AB_Spanner m_spanner;
          protected AB_CheckSendMsg m_checkSendMsg;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_rotateControl)
               {//开始控制手柄的旋转
                    fnp_findSpanner();
                    if (m_spanner == null)
                    {
                         return;
                    }
                    if (_button == E_buttonIndex.e_triggerDown)
                    {
                         m_spanner.fn_startControl(_hand.fni_getHandRigid().transform);
                         if (m_isCountDown)
                         {
                              m_countdownUI.fn_endCountDown();
                              CancelInvoke("fnp_Pull");
                              m_isCountDown = false;
                         }
                         //开始检查,到达条件发送值
                         m_checkSendMsg.fn_StartCheck();
                         //Debug.Log("<color=blue>旋转1:</color>");
                    }
                    if (_button == E_buttonIndex.e_triggerUp)
                    {
                         fnp_handEndControl();
                         //结束检查，关闭发送值通道
                         m_checkSendMsg.fn_endCheck();
                    }

               }


          }
          /// <summary>
          /// 手柄停止对把手的旋转
          /// </summary>
          protected virtual void fnp_handEndControl()
          {
               m_spanner.fn_endControl();
          }

          private void fnp_findSpanner()
          {
               if (m_spanner == null)
               {
                    m_spanner = GetComponent<AB_Spanner>();
               }
               if (m_spanner == null)
               {
                    m_spanner = GetComponentInChildren<AB_Spanner>();
               }
               if (m_countdownUI == null)
               {
                    m_countdownUI = GetComponentInChildren<AB_CountDown>();
               }
               if (m_checkSendMsg == null)
               {
                    m_checkSendMsg = GetComponent<AB_CheckSendMsg>();
               }
               if (m_checkSendMsg == null)
               {
                    m_checkSendMsg = gameObject.AddComponent<N_YaobaSendMsg>();
               }
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               fnp_findSpanner();

               //碰触到摇把，但是没有做摇入摇出动作，在等待2s钟为取出
               if (m_rotateControl && _inOut && m_spanner.fni_valueToEdge())
               {
                    if (m_isCountDown)
                    {
                         return;
                    }
                    m_isCountDown = true;
                    Invoke("fnp_Pull", 2f);
                    m_countdownUI.fn_startCountDown(2f);
               }
               if (_inOut == false)
               {
                    if (m_isCountDown)
                    {
                         m_countdownUI.fn_endCountDown();
                         CancelInvoke("fnp_Pull");
                         m_isCountDown = false;
                    }
               }

          }
          //倒计时
          bool m_isCountDown = false;
          /// <summary>
          /// 拔出把手
          /// </summary>
          protected virtual void fnp_Pull()
          {
               m_spanner.fn_endControl();
               m_rotateControl = false;
               m_isCountDown = false;
               //m_rotateControl = false;
               Rigidbody t_rg = GetComponent<Rigidbody>();

               //testYaoba t_testyaoba = GetComponentInChildren<testYaoba>();
               //if (t_testyaoba != null)
               //{
               //     t_testyaoba.fnp_reset();
               //     t_testyaoba.m_handleTrigger.SetActive(false);
               //     //Destroy(t_testyaoba);
               //}
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
               if (t_setRotateSound!=null)
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
               if (m_PullOutBackToZero)
               {
                    m_spanner.fn_setTo(0f);
               }
          }
          /// <summary>
          /// 从机器拔出是否旋转回到开始位置
          /// 这样做的原因是拉出把手后，需要碰撞体和手接触才能放下把手
          /// </summary>
          public bool m_PullOutBackToZero = true;
          private void fnp_wakeCollider()
          {
               MeshCollider t_mc = GetComponentInChildren<MeshCollider>();
               if (t_mc != null)
               {
                    t_mc.enabled = true;
               }
          }


     } 
}
