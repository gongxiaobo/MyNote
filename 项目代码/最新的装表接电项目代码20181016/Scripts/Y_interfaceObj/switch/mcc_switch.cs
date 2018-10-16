using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 这类型的旋钮处理的是左1中0右2的3个档位的处理
     /// </summary>
     public class mcc_switch : CaculateAngelLSLogic
     {

          //private AB_HandleEvent m_handleEvent;
          protected override void Start()
          {
               base.Start();
               //m_handleEvent = GetComponentInParent<AB_HandleEvent>();
          }
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               if (_value == m_limitRang.x)
                    fn_switch_shift(1);
               else if (_value == m_limitRang.y)
                    fn_switch_shift(2);
               else
                    fn_switch_shift(0);
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
               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);

               //Debug.Log("<color=blue>blue:</color>" + _statename + "=" + _value);

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
               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _level.ToString(), m_handleEvent);
          }

     }

}