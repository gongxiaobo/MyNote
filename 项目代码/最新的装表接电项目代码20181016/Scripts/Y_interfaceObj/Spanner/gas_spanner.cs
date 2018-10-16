using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum GasValveType { 
//    angle90=1,
//    angle720=2,
//}
namespace GasPowerGeneration
{
     /// <summary>
     /// 2018.6.29添加在状态改变的时候，一些效果的处理
     /// </summary>
     public class gas_spanner : CaculateAngelLimit_Logic
     {
          public override void fn_endControl()
          {
               base.fn_endControl();
               if (AllRotate <= m_limitRang.x)//0
               {
                    fn_setTo(m_limitRang.x);
                    fn_switch_shift(true);
               }
               else if (AllRotate >= m_limitRang.y)//90
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
                         m_handleEvent.GetComponent<AB_State>().fn_debugContent();
                    }
                    fnp_Result("on");
                    fnp_effect(E_effectType.e_on, E_effectName.e_tips);
               }
               else
               {
                    StateValueString t_value = (StateValueString)m_handleEvent.fn_get("onoff");
                    if (t_value != null)
                    {
                         t_value.m_date = "off";
                         m_handleEvent.fn_set(t_value);
                         m_handleEvent.GetComponent<AB_State>().fn_debugContent();
                    }
                    fnp_Result("off");
                    fnp_effect(E_effectType.e_off, E_effectName.e_tips);
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

          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               base.fni_stateChange(_statename, _value, _controlType);
               if (_statename == "electric")
               {
                    if (_value=="con")
                    {
                         if (m_handleEvent.fn_getMainValue()=="on")
                         {
                              fnp_effect(E_effectType.e_on, E_effectName.e_tips);
                         }
                         else
                         {

                         }
                    }
                    else
                    {
                         if (m_handleEvent.fn_getMainValue() == "on")
                         {
                              fnp_effect(E_effectType.e_off, E_effectName.e_tips);
                         }
                         else
                         {

                         }
                    }
               }
          }

     }

}