using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理按钮类型的开关效果
     /// 处理了条件判断和反射的触发
     /// </summary>
     public class N_ButtonBase : N_Spanner
     {
          protected override void Start()
          {
               base.Start();
               m_condition = GetComponent<AB_Condition>();
               m_resultAction = GetComponent<AB_ResultAction>();
               fnp_setSpeed(m_AniSpeed);
          }
          public string m_state = "off";
          public override void fn_startControl(Transform _hand)
          {
               base.fn_startControl(_hand);
               //fn_setTo("on");
               if (m_state == "off")
               {
                    fni_on();
               }
               else
               {
                    fni_off();
               }
          }
          public override void fn_endControl()
          {
               base.fn_endControl();
               //m_handleEvent.fn_debugState();
          }
          protected virtual void fnp_setSpeed(float _speed)
          {
               if (m_animator != null)
               {
                    m_animator.speed = _speed;
               }
          }
          public float m_AniSpeed = 3.5f;
          public override void fn_setTo(string _com)
          {

               base.fn_setTo(_com);
               fnp_setSpeed(m_AniSpeed);
               if (m_state == "off")
               {
                    m_state = "on";
                    fnp_play();
                    //fnp_onMessage();
               }
               else
               {
                    m_state = "off";
                    //fnp_offMessage();
                    fnp_play();
               }
          }

          protected void fnp_play()
          {
               if (m_animator != null)
               {
                    m_animator.SetTrigger(m_state);
               }
          }
          /// <summary>
          /// 条件集合
          /// </summary>
          protected AB_Condition m_condition = null;
          /// <summary>
          /// 触发结果的影响
          /// </summary>
          protected AB_ResultAction m_resultAction = null;
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               fnp_findCR();
               if (_controlType == E_ControlType.e_normal)
               {
                    if (m_state == "off")
                    {//条件
                         bool t_pass = (m_condition != null) ? m_condition.fn_check("on") : true;
                         if (t_pass)
                         {
                              m_state = "on";
                              fnp_play();
                              fnp_onMessage();
                         }

                    }
               }
               if (_controlType == E_ControlType.e_init)
               {
                    if (m_state == "off")
                    {
                         m_state = "on";
                         fnp_play();
                    }
               }
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               fnp_findCR();
               if (_controlType == E_ControlType.e_normal)
               {
                    if (m_state == "on")
                    {
                         //条件
                         bool t_pass = (m_condition != null) ? m_condition.fn_check("off") : true;
                         if (t_pass)
                         {
                              m_state = "off";
                              fnp_offMessage();
                              fnp_play();
                         }

                    }
               }
               if (_controlType == E_ControlType.e_init)
               {
                    if (m_state == "on")
                    {
                         m_state = "off";
                         fnp_play();
                    }
               }
          }
          /// <summary>
          /// 播放声音
          /// </summary>
          /// <param name="_name"></param>
          protected virtual void fnp_onoffSound(string _name)
          {
               S_SoundComSingle.Instance.fnp_sound(_name);
          }
          /// <summary>
          /// 按钮按下的消息发送
          /// </summary>
          protected virtual void fnp_onMessage()
          {

               fnp_onoffSound("btn_down");
               //产生结果
               fnp_Result("on");
          }
          /// <summary>
          /// 按钮关闭的消息发送
          /// </summary>
          protected virtual void fnp_offMessage()
          {
               fnp_onoffSound("btn_down");
               //产生结果
               fnp_Result("off");
          }
          /// <summary>
          /// 根据类型，播放指定名称的效果
          /// </summary>
          /// <param name="_type"></param>
          /// <param name="_name"></param>
          protected virtual void fnp_effect(E_effectType _type, E_effectName _name) { }
          /// <summary>
          /// 产生的结果消息发送
          /// </summary>
          /// <param name="_name"></param>
          protected virtual void fnp_Result(string _name)
          {
               fnp_findCR();
               if (m_resultAction != null)
               {
                    m_resultAction.fn_SendResultMsg(_name, m_handleEvent);

                    //Debug.Log("<color=red>产生的结果消息发送:</color>");

               }
          }
          protected virtual void fnp_findCR()
          {
               m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               m_condition = m_condition ?? GetComponent<AB_Condition>();
          }
     }

}