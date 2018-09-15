using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器卡槽的状态改变
     /// </summary>
     public class N_FuseLogic : N_OnlyValueLogic
     {
          protected AB_FuseState m_fuseState = null;
          protected AB_haveFuse m_havefuse = null;
          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findfusestate();
               //base.fni_on(_controlType);
               fnp_findCR();
               if (_controlType == E_ControlType.e_init)
               {
                    fnp_setValue("on");

               }
               else
               {
                    fnp_setValue("on");
                    //触发条件
                    AB_SendResult t_result = new N_SendResult();
                    if (m_handleEvent.fn_getValue("electric") == "con" && m_fuseState.fn_CanWork())
                    {//关闭抽屉有电的情况

                         t_result.fn_SendResult("on", GetComponent<AB_ResultAction>(), m_handleEvent);
                    }
                    else
                    {//关闭抽屉无电的情况
                         //t_result.fn_SendResult("off", GetComponent<AB_ResultAction>(), m_handleEvent);
                    }
               }
          }

          private void fnp_findfusestate()
          {
               if (m_fuseState == null)
               {
                    m_fuseState = GetComponent<AB_FuseState>();
               }
          }

          private void fnp_setValue(string _value)
          {
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("onoff", _value, m_handleEvent);

          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               fnp_findfusestate();
               //base.fni_off(_controlType);
               fnp_findCR();
               if (_controlType == E_ControlType.e_init)
               {
                    fnp_setValue("off");
               }
               else
               {
                    fnp_setValue("off");
                    //触发条件
                    AB_SendResult t_result = new N_SendResult();
                    //if (m_handleEvent.fn_getValue("electric") == "con")
                    //{//关闭抽屉有电的情况

                    t_result.fn_SendResult("off", GetComponent<AB_ResultAction>(), m_handleEvent);
                    //}

               }
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               //

               //Debug.Log("<color=red>熔断器来电=</color>"+_value);

               fnp_findfusestate();
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         if (m_handleEvent.fn_getValue("onoff") == "on" && m_fuseState.fn_CanWork())
                         {
                              //Debug.Log("<color=red>熔断器触发条件通过=</color>" + _value);
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
