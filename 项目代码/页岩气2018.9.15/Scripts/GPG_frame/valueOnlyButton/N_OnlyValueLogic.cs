using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 开关值类型的逻辑处理
     /// </summary>
     public class N_OnlyValueLogic : AB_OnlyValue
     {
          protected AB_HandleEvent m_handleEvent = null;
          /// <summary>
          /// 条件集合
          /// </summary>
          protected AB_Condition m_condition = null;
          /// <summary>
          /// 触发结果的影响
          /// </summary>
          protected AB_ResultAction m_resultAction = null;
          protected override void Start()
          {
               base.Start();
               m_handleEvent = GetComponent<AB_HandleEvent>();
          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);

               fnp_findCR();
               if (_controlType == E_ControlType.e_init)
               {
                    StateValue t_sv = m_handleEvent.fn_get("onoff");
                    if (t_sv != null)
                    {
                         StateValueString t_s = t_sv as StateValueString;
                         t_s.m_date = "on";
                         m_handleEvent.fn_set(t_s);
                         fnp_On();
                    }
               }
               else
               {
                    if (m_handleEvent != null)
                    {
                         if (m_handleEvent.fn_getMainValue() == "off")
                         {//开
                              //条件
                              bool t_pass = (m_condition != null) ? m_condition.fn_check("on") : true;
                              if (t_pass)
                              {
                                   //Debug.Log("<color=blue>气阀通过1:</color>");
                                   StateValue t_sv = m_handleEvent.fn_get("onoff");
                                   if (t_sv != null)
                                   {
                                        StateValueString t_s = t_sv as StateValueString;
                                        t_s.m_date = "on";
                                        m_handleEvent.fn_set(t_s);
                                        fnp_Result("on");
                                   }
                                   fnp_On();
                                   //m_handleEvent.fn_set()
                              }
                         }
                    }
               }
               m_handleEvent.fn_debugState();
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               fnp_findCR();
               if (_controlType == E_ControlType.e_init)
               {
                    StateValue t_sv = m_handleEvent.fn_get("onoff");
                    if (t_sv != null)
                    {
                         StateValueString t_s = t_sv as StateValueString;
                         t_s.m_date = "off";
                         m_handleEvent.fn_set(t_s);
                         fnp_Off();
                    }
               }
               else
               {
                    if (m_handleEvent != null)
                    {
                         if (m_handleEvent.fn_getMainValue() == "on")
                         {//关
                              //条件
                              bool t_pass = (m_condition != null) ? m_condition.fn_check("off") : true;
                              if (t_pass)
                              {
                                   StateValue t_sv = m_handleEvent.fn_get("onoff");
                                   if (t_sv != null)
                                   {
                                        StateValueString t_s = t_sv as StateValueString;
                                        t_s.m_date = "off";
                                        m_handleEvent.fn_set(t_s);
                                        fnp_Result("off");
                                   }
                                   //m_handleEvent.fn_set()
                                   fnp_Off();
                              }
                         }
                    }
               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               fnp_findCR();


          }
          protected virtual void fnp_findCR()
          {
               if (m_resultAction == null)
               {
                    m_resultAction = GetComponent<AB_ResultAction>();
               }
               if (m_condition == null)
               {
                    m_condition = GetComponent<AB_Condition>();
               }
               if (m_condition == null || m_resultAction == null)
               {

                    Debug.Log("<color=red>m_condition==null || m_resultAction==null</color>");

               }

          }
          protected virtual void fnp_Result(string _name)
          {
               fnp_findCR();
               if (m_resultAction != null)
               {
                    m_resultAction.fn_SendResultMsg(_name, m_handleEvent);

                    //Debug.Log("<color=red>产生的结果消息发送:</color>");

               }
          }
          protected virtual void fnp_On()
          {
          }
          protected virtual void fnp_Off()
          {
          }
          /// <summary>
          /// 根据类型，播放指定名称的效果
          /// </summary>
          /// <param name="_type"></param>
          /// <param name="_name"></param>
          protected virtual void fnp_effect(E_effectType _type, E_effectName _name)
          {
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name == null)
               {
                    return;
               }
               List<AB_effect> t_effects = S_SceneMagT1.Instance.fn_getEffect(t_name.m_ID);
               if (t_effects != null)
               {
                    for (int i = 0; i < t_effects.Count; i++)
                    {
                         if (t_effects[i].m_effectName == _name)
                         {
                              t_effects[i].fn_effect(_type, "");
                         }
                    }
               }
          }
     }

}