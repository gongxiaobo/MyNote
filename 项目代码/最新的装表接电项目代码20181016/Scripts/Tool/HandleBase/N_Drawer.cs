using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 抽屉的动画控制,设置状态值
     /// </summary>
     public class N_Drawer : Door_90
     {

          public override void fn_startControl(Transform _movehand)
          {
               AB_CheckCondition t_check = new N_CheckCondition();
               if (t_check.fn_check("lock", GetComponent<AB_Condition>()))
               {//没有被锁定,抽屉才能被打开
                    base.fn_startControl(_movehand);
               }

          }
          public override void fn_endControl()
          {

               if (m_isControl)
               {
                    base.fn_endControl();
                    if (m_lastTime == m_min)
                    {//关闭抽屉
                         fni_on();
                    }
                    else if (m_lastTime == m_max)
                    {//开启抽屉
                         fni_off();
                    }
               }
          }
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_setstate = new N_SetState();
                    t_setstate.fn_setState("onoff", "on", m_handleEvent);
                    AB_SendResult t_result = new N_SendResult();
                    if (m_handleEvent.fn_getValue("electric") == "con")
                    {//关闭抽屉有电的情况

                         t_result.fn_SendResult("on", GetComponent<AB_ResultAction>(), m_handleEvent);
                    }
                    else
                    {//关闭抽屉无电的情况
                         //t_result.fn_SendResult("off", GetComponent<AB_ResultAction>(), m_handleEvent);
                    }
               }

          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               if (_controlType == E_ControlType.e_normal)
               {
                    AB_SetState t_setstate = new N_SetState();
                    t_setstate.fn_setState("onoff", "off", m_handleEvent);
                    AB_SendResult t_result = new N_SendResult();
                    t_result.fn_SendResult("off", GetComponent<AB_ResultAction>(), m_handleEvent);
               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               if (_statename == "electric")
               {

                    //Debug.Log("<color=red>抽屉来电</color>" + _value);

                    if (_value == "con")
                    {
                         if (m_handleEvent.fn_getValue("onoff") == "on")
                         {
                              AB_SendResult t_result = new N_SendResult();
                              t_result.fn_SendResult("on", GetComponent<AB_ResultAction>(), m_handleEvent);
                         }
                    }
                    else
                    {
                         if (m_handleEvent.fn_getValue("onoff") == "on")
                         {
                              AB_SendResult t_result = new N_SendResult();
                              t_result.fn_SendResult("off", GetComponent<AB_ResultAction>(), m_handleEvent);
                         }
                    }
               }
          }

     } 
}
