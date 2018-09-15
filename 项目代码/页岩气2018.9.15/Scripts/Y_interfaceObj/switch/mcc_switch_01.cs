using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// mcc柜抽屉1A的开关
     /// 
     /// </summary>
     public class mcc_switch_01 : CaculateAngelLSOnlyLogic
     {
          protected override void fnp_nearValue(float _value)
          {
               base.fnp_nearValue(_value);
               //
               if (_value == -90)
               {//在关闭位置0
                    fnp_changeState("0");
               }
               else if (_value == 0)
               {//开1
                    fnp_changeState("1");
               }
               else if (_value == -180)
               {//拉出抽屉2
                    fnp_changeState("2");
               }
          }
          //用于初始化设置，改变state的level值
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findCR();
               base.fni_level(_level, _controlType);
               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _level.ToString(), m_handleEvent);
               if (_controlType == E_ControlType.e_normal)
               {//在操作普通状态，触发条件
                    AB_SendResult t_sendresult = new N_SendResult();
                    t_sendresult.fn_SendResult(_level.ToString(), m_resultAction, m_handleEvent);
               }
          }
          private void fnp_changeState(string _value)
          {
               fnp_findCR();
               //改变自身状态值
               AB_SetState t_setstate = new N_SetState();
               t_setstate.fn_setState("level", _value, m_handleEvent);
               //触发反射
               AB_SendResult t_sendresult = new N_SendResult();
               t_sendresult.fn_SendResult(_value, m_resultAction, m_handleEvent);
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findCR();
               base.fni_stateChange(_statename, _value, _controlType);
               if (_statename == "electric")
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("level");
                    if (t_value != null)
                    {
                         string t_level = t_value.m_date;

                         if (_value == "con")
                         {
                              //Debug.Log("<color=red>1号发电机A散热风机的总控制开关=</color>" + _value + t_level);
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