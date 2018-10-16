using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 对应35kv的链接装置的控制，状态的设置，条件的触发
     /// </summary>
     public class N_35kvHandleRL : Door_90
     {
          protected override void Start()
          {
               base.Start();
          }
          public override void fn_startControl(Transform _movehand)
          {
               AB_CheckCondition t_c = new N_CheckCondition();
               if (t_c.fn_check("canuse", GetComponent<AB_Condition>()))
               {
                    base.fn_startControl(_movehand);
               }

          }
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (m_lastTime == m_min)
               {//关
                    fni_off(E_ControlType.e_normal);
               }
               if (m_lastTime == m_max)
               {//开
                    fni_on(E_ControlType.e_normal);

               }
          }

          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    fnp_setStateOn("on");
                    fnp_setAni(m_max);
               }
               else
               { //设置状态值
                    if (m_handleEvent.fn_getMainValue()=="on")
                    {
                         return;
                    }
                    fnp_setStateOn("on");
                    //反射链
                    AB_ResultAction t_ra = GetComponent<AB_ResultAction>();
                    if (t_ra!=null)
                    {
                         t_ra.fn_SendResultMsg("on", m_handleEvent); 
                    }
                    fnp_setAni(m_max);
               }
              

          }

          private void fnp_setStateOn(string _state)
          {
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("onoff", _state, m_handleEvent);
          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    fnp_setStateOn("off");
                    fnp_setAni(m_min);
               }
               else
               {
                    if (m_handleEvent.fn_getMainValue() == "off")
                    {
                         return;
                    }
                    fnp_setStateOn("off");
                    //反射链
                    AB_ResultAction t_ra = GetComponent<AB_ResultAction>();
                    if (t_ra != null)
                    {
                         t_ra.fn_SendResultMsg("off", m_handleEvent);
                    }
                    fnp_setAni(m_min);
               }
               
          }
          //protected virtual void fnp_findCR()
          //{
          //     m_resultAction = m_resultAction ?? GetComponent<AB_ResultAction>();
          //     //m_condition = m_condition ?? GetComponent<AB_Condition>();
          //}
          //protected virtual void fnp_Result(string _name)
          //{
          //     fnp_findCR();
          //     if (m_resultAction != null)
          //     {
          //          m_resultAction.fn_SendResultMsg(_name, m_handleEvent);

          //          //Debug.Log("<color=red>产生的结果消息发送:</color>");

          //     }
          //}
     }

}