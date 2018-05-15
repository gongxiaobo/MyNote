using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class CaculateAngelLimit_Logic : CaculateAngelLimit
     {
          protected AB_HandleEvent m_handleEvent;
          /// <summary>
          /// 条件集合
          /// </summary>
          protected AB_Condition m_condition = null;
          /// <summary>
          /// 触发结果的影响
          /// </summary>
          protected AB_ResultAction m_resultAction = null;
          private void fnp_findCR()
          {
               //m_condition = m_condition ?? GetComponent<AB_Condition>();
               //m_condition = m_condition ?? GetComponentInParent<AB_Condition>();
               //m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               //m_resultAction = m_resultAction ?? GetComponentInParent<AB_ResultAction>();
               if (m_handleEvent == null)
               {
                    m_handleEvent = GetComponent<AB_HandleEvent>();
               }
               if (m_handleEvent == null)
               {
                    m_handleEvent = GetComponentInParent<AB_HandleEvent>();
               }
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
          protected override void Start()
          {
               base.Start();

               if (m_handleEvent == null)
               {
                    m_handleEvent = GetComponent<AB_HandleEvent>();
               }
               if (m_handleEvent == null)
               {
                    m_handleEvent = GetComponentInParent<AB_HandleEvent>();
               }
               //
               fnp_findCR();
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

                    Debug.Log("<color=red>产生的结果消息发送:</color>" + _name);

               }
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