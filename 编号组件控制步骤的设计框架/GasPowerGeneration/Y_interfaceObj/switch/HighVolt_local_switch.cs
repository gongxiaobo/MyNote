using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class HighVolt_local_switch : CaculateAngelLimit_Logic
     {

          ////private AB_HandleEvent m_handleEvent;
          //protected override void Start()
          //{
          //    base.Start();
          //    //m_handleEvent = GetComponentInParent<AB_HandleEvent>();
          //}
          //protected override void fnp_nearValue(float _value)
          //{
          //    base.fnp_nearValue(_value);
          //    if (_value == m_limitRang.x)
          //        fn_switch_shift(true);
          //    else if (_value == m_limitRang.y)
          //        fn_switch_shift(false);
          //}
          ///// <summary>
          ///// 根据输入值发送消息
          ///// </summary>
          ///// <param name="level"></param>
          //private void fn_switch_shift(bool onoff)
          //{

          //    if (onoff)
          //    {
          //        StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
          //        if (t_value != null)
          //        {
          //            t_value.m_date = "on";
          //            m_handleEvent.fn_set(t_value);
          //        }
          //    }
          //    else
          //    {
          //        StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
          //        if (t_value != null)
          //        {
          //            t_value.m_date = "off";
          //            m_handleEvent.fn_set(t_value);
          //        }
          //    }
          //}
          //public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          //{
          //    base.fni_stateChange(_statename, _value, _controlType);

          //    Debug.Log("<color=blue>blue:</color>" + _statename + "=" + _value);

          //    if (_statename == "electric")
          //    {
          //        StateValueString t_value = (StateValueString)m_handleEvent.fn_get("level");
          //        if (t_value != null)
          //        {
          //            string t_level = t_value.m_date;
          //            //if (t_value.m_date == (m_limitRang.x).ToString())
          //            //     t_level="1";
          //            //else if (t_value.m_date == (m_limitRang.y).ToString())
          //            //     t_level = "2";
          //            //else
          //            //     t_level = "0";
          //            if (_value == "con")
          //            {
          //                m_resultAction.fn_SendResultMsg(t_level, m_handleEvent);
          //            }
          //            else
          //            {
          //                m_resultAction.fn_SendResultMsg("0", m_handleEvent);
          //            }



          //        }
          //    }

          //}
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (AllRotate <= (m_limitRang.y + m_limitRang.x) * 0.5f)//0
               {
                    fn_setTo(m_limitRang.x);
                    fn_switch_shift(true);
               }
               else if (AllRotate >= (m_limitRang.y + m_limitRang.x) * 0.5f)//90
               {
                    fn_setTo(m_limitRang.y);
                    fn_switch_shift(false);
               }
          }
          private void fn_switch_shift(bool onoff)
          {
               if (onoff)
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
                    if (t_value != null)
                    {
                         t_value.m_date = "on";
                         m_handleEvent.fn_set(t_value);
                    }
                    fnp_Result("on");
               }
               else
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
                    if (t_value != null)
                    {
                         t_value.m_date = "off";
                         m_handleEvent.fn_set(t_value);
                    }
                    fnp_Result("off");
               }
          }

          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_on(_controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    fn_setTo(m_limitRang.x);
               }

          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    fn_setTo(m_limitRang.y);
               }
          }

     }

}