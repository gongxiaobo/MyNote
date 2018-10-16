using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 旋钮3个档位的逻辑触发
     /// </summary>
     public class CaculateAngelLSLogic : CaculateAngelLimitSub
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
               m_handleEvent = GetComponent<AB_HandleEvent>();
               m_handleEvent = m_handleEvent ?? GetComponentInParent<AB_HandleEvent>();
               //
               fnp_findCR();
          }

          private void fnp_findCR()
          {
               m_condition = m_condition ?? GetComponent<AB_Condition>();
               m_condition = m_condition ?? GetComponentInParent<AB_Condition>();
               m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
               m_resultAction = m_resultAction ?? GetComponentInParent<AB_ResultAction>();
          }
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               fnp_findCR();
               if (m_resultAction == null || m_handleEvent == null)
               {
                    return;
               }
               if (_value == m_limitRang.x)
                    m_resultAction.fn_SendResultMsg("1", m_handleEvent);
               else if (_value == m_limitRang.y)
                    m_resultAction.fn_SendResultMsg("2", m_handleEvent);
               else
                    m_resultAction.fn_SendResultMsg("0", m_handleEvent);
          }
     }

}