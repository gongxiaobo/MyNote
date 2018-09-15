using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 两个档位的旋钮
     /// </summary>
     public class mcc_switch_2level : CaculateAngelLSOnlyLogic
     {
          public float m_levelLeft = 0f, m_levelRight = 90f;
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               //
               if (_value == m_levelLeft)
               {//在关闭位置0
                    fnp_changeState("0");
               }
               else if (_value == m_levelRight)
               {//开1
                    fnp_changeState("1");
               }

          }

          private void fnp_changeState(string _value)
          {
               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _value, m_handleEvent);
               //触发反射
               AB_SendResult t_sendresult = new N_SendResult();
               t_sendresult.fn_SendResult(_value, m_resultAction, m_handleEvent);
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               if (_statename == "electric")
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("level");
                    if (t_value != null)
                    {
                         string t_level = t_value.m_date;

                         if (_value == "con")
                         {
                              AB_SendResult t_sendresult = new N_SendResult();
                              t_sendresult.fn_SendResult(t_level, m_resultAction, m_handleEvent);
                         }
                         //else
                         //{
                         //     m_resultAction.fn_SendResultMsg(t_level, m_handleEvent);
                         //}



                    }
               }
          }
     }

}