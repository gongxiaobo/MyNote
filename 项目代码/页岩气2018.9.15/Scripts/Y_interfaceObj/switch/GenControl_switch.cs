using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class GenControl_switch : CaculateAngelLSLogic
     {

          //private AB_HandleEvent m_handleEvent;
          protected override void Start()
          {
               base.Start();
               //m_handleEvent = GetComponentInParent<AB_HandleEvent>();
          }
          protected override void fnp_nearValue(float _value)
          {
               N_CheckCondition condition = new N_CheckCondition();
               base.fnp_nearValue(_value);
               print(_value);
               if (_value == -90)
               {
                    fn_switch_shift(4);
                    fnp_effect(E_effectType.e_off, E_effectName.e_light);
                    fnp_effect(E_effectType.e_off, E_effectName.e_sound);
               }
               else if (_value == 90)
               {
                    if (!condition.fn_check("start_gen", GetComponent<AB_Condition>()))
                    {
                         fn_switch_shift(2);
                         fnp_effect(E_effectType.e_on, E_effectName.e_light);
                         fnp_effect(E_effectType.e_on, E_effectName.e_sound);
                    }
               }
               else if (_value == 0)
               {
                    fn_switch_shift(1);

                    fnp_effect(E_effectType.e_off, E_effectName.e_light);
                    fnp_effect(E_effectType.e_off, E_effectName.e_sound);
               }
               else if (_value == 180)
               {
                    if (condition.fn_check("start_gen", GetComponent<AB_Condition>()))
                    {
                         fn_switch_shift(3);
                         fnp_effect(E_effectType.e_on, E_effectName.e_light);
                         fnp_effect(E_effectType.e_on, E_effectName.e_sound);
                    }
               }
          }
          /// <summary>
          /// 根据输入值发送消息
          /// </summary>
          /// <param name="level"></param>
          private void fn_switch_shift(int level)
          {

               StateValueString t_value = (StateValueString)m_handleEvent.fn_get("level");
               if (t_value != null)
               {
                    t_value.m_date = level.ToString();
                    //AB_Message msg = new N_Message();
                    //msg.fn_init( E_MessageType.e_inside,new StateValueString[1]{t_value},
                    m_handleEvent.fn_set(t_value);
                    m_handleEvent.GetComponent<AB_State>().fn_debugContent();
                    fnp_Result(level.ToString());
               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);

               Debug.Log("<color=blue>blue:</color>" + _statename + "=" + _value);

               if (_statename == "electric")
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("level");
                    if (t_value != null)
                    {
                         string t_level = t_value.m_date;
                         //if (t_value.m_date == (m_limitRang.x).ToString())
                         //     t_level="1";
                         //else if (t_value.m_date == (m_limitRang.y).ToString())
                         //     t_level = "2";
                         //else
                         //     t_level = "0";
                         if (_value == "con")
                         {
                              m_resultAction.fn_SendResultMsg(t_level, m_handleEvent);
                         }
                         else
                         {
                              m_resultAction.fn_SendResultMsg("0", m_handleEvent);
                         }



                    }
               }

          }


          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_level(_level, _controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    switch (_level)
                    {
                         case 1:
                              fn_setTo(0);
                              break;
                         case 2:
                              fn_setTo(90);
                              break;
                         case 3:
                              fn_setTo(180);
                              break;
                         case 4:
                              fn_setTo(-90);
                              break;
                         default:
                              break;

                    }
               }
          }
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
               //m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               //m_condition = m_condition ?? GetComponent<AB_Condition>();
               if (m_condition == null)
               {
                    m_condition = GetComponent<AB_Condition>();
               }
               if (m_condition == null)
               {
                    m_condition = GetComponentInParent<AB_Condition>();
               }
               if (m_resultAction == null)
               {
                    m_resultAction = GetComponent<AB_ResultAction>();
               }
               if (m_resultAction == null)
               {
                    m_resultAction = GetComponentInParent<AB_ResultAction>();
               }
               if (m_condition == null || m_resultAction == null)
               {

                    Debug.Log("<color=red>m_condition==null || m_resultAction==null</color>");

               }
          }

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