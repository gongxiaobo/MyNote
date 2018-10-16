using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 加入条件获取和消息接收类
     /// </summary>
     public class CaculateAngelLSOnlyLogic : CaculateAngelLimitSub
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
               Invoke("fnp_findCR", 0.51f);
               //fnp_findCR();
          }

          protected void fnp_findCR()
          {
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
               //下面这种写法容易找不到物体,不能使用这种方式来工作
               //m_condition = m_condition ?? GetComponent<AB_Condition>();
               //m_condition = m_condition ?? GetComponentInParent<AB_Condition>();
               //m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               //m_resultAction = m_resultAction ?? GetComponentInParent<AB_ResultAction>();
          }
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               fnp_findCR();
               //if (m_resultAction == null || m_handleEvent == null)
               //{
               //     return;
               //}
               //if (_value == m_limitRang.x)
               //     m_resultAction.fn_SendResultMsg("1", m_handleEvent);
               //else if (_value == m_limitRang.y)
               //     m_resultAction.fn_SendResultMsg("2", m_handleEvent);
               //else
               //     m_resultAction.fn_SendResultMsg("0", m_handleEvent);
          }

     }

}