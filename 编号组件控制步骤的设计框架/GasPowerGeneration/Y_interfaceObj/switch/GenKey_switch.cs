using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class GenKey_switch : CaculateAngelLimit_Logic
     {

          public override void fn_endControl()
          {
               base.fn_endControl();
               if (AllRotate <= (m_limitRang.y + m_limitRang.x) * 0.5f)//0
               {
                    fn_setTo(m_limitRang.x);
                    fn_switch_shift(false);
               }
               else if (AllRotate >= (m_limitRang.y + m_limitRang.x) * 0.5f)//90
               {
                    fn_setTo(m_limitRang.y);
                    fn_switch_shift(true);
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
                    fn_setTo(m_limitRang.y);
                    //改变自身状态值
                    AB_SetState t_setstate = new N_SetState();
                    t_setstate.fn_setState("onoff", "on", m_handleEvent);
               }

          }
          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_off(_controlType);
               if (_controlType == E_ControlType.e_init)
               {
                    fn_setTo(m_limitRang.x);
                    //改变自身状态值
                    AB_SetState t_setstate = new N_SetState();
                    t_setstate.fn_setState("onoff", "off", m_handleEvent);
               }
          }

     }

}