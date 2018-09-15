using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdp;
using DG.Tweening;
namespace GasPowerGeneration
{
     public class Show_cdpscreen : MonoBehaviour, I_Control
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

          bool first_show = true;
          protected virtual void Start()
          {
               m_condition = GetComponent<AB_Condition>();
               m_resultAction = GetComponent<AB_ResultAction>();
               handler = GetComponent<N_HandleEvent_init>();

          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {


               if (_controlType == E_ControlType.e_init)
               {
                    if (first_show)
                    {
                         CDPctrl_manager.Instance.Init();
                         first_show = false;
                    }

               }
               else
               {
                    CDPctrl_manager.Instance.transform.DOScale(1, 0);
                    AB_CheckCondition t_cc = new N_CheckCondition();
                    if (!t_cc.fn_check("ele", m_condition))
                    {
                         return;
                    }
                    if (first_show)
                    {
                         CDPctrl_manager.Instance.Init();
                         first_show = false;

                    }
                    StateValueString m_state = (StateValueString)handler.fn_get("onoff");
                    m_state.m_date = "on";
                    handler.fn_set(m_state);

               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               CDPctrl_manager.Instance.transform.DOScale(0, 0);
               //if (_controlType == E_ControlType.e_init)
               //{
               //    CDPctrl_manager.Instance.transform.DOScale(0, 0);

               //}
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         CDPctrl_manager.Instance.Init();
                         first_show = false;
                         CDPctrl_manager.Instance.transform.DOScale(1, 0);
                    }
                    else
                    {
                         CDPctrl_manager.Instance.fn_changepanel(cdp_panel_type.Null);
                         CDPctrl_manager.Instance.transform.DOScale(0, 0);
                    }


               }
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
     }

}