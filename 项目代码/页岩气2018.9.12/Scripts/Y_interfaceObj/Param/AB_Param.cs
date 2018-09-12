using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class AB_Param : MonoBehaviour, I_Control, I_paramshow
     {
          /// <summary>
          /// 条件集合
          /// </summary>
          protected AB_Condition m_condition = null;
          /// <summary>
          /// 触发结果的影响
          /// </summary>
          protected AB_ResultAction m_resultAction = null;

          protected N_HandleEvent_init handler;
          // Use this for initialization
          protected virtual void Start()
          {
               m_condition = GetComponent<AB_Condition>();
               m_resultAction = GetComponent<AB_ResultAction>();
               handler = GetComponent<N_HandleEvent_init>();
          }
          protected virtual void OnEnable()
          {

          }

          public virtual void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public virtual void fn_show_param(int value)
          {
          }

          public virtual void fn_show_param(float value)
          {
          }

          public virtual void fn_show_unit()
          {
          }

          public virtual RectTransform fn_getrect()
          {
               return null;
          }
          /// <summary>
          /// 产生的结果消息发送
          /// </summary>
          /// <param name="_name"></param>
          public virtual void fnp_Result(string _name)
          {
               fnp_findCR();
               if (m_resultAction != null)
               {
                    m_resultAction.fn_SendResultMsg(_name, handler);

                    //Debug.Log("<color=red>产生的结果消息发送:</color>");

               }
          }
          public virtual void fnp_findCR()
          {
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
               //m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               //m_condition = m_condition ?? GetComponent<AB_Condition>();
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
