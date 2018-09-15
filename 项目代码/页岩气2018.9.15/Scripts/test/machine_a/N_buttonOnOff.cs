using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_buttonOnOff : AB_buttonOnOff, I_Control
     {

          AB_HandleEvent m_handle;
          public override void fn_on()
          {
               if (m_handle == null)
               {
                    m_handle = GetComponent<AB_HandleEvent>();

               }
               StateValueString t_value = (StateValueString)m_handle.fn_get("onoff");
               if (t_value.m_date == "off")
               {
                    fnp_change("on");
                    t_value.m_date = "on";
                    //m_handle.fn_set(t_value);

                    AB_Message t_msg = new N_Message();
                    t_msg.fn_init(E_MessageType.e_changeState,
                         new StateValue[1] { t_value }, "change");
                    m_handle.fn_HandleMsg(t_msg);
               }
               else
               {
                    fn_off();
               }
          }

          private void fnp_changeState(string _state)
          {

               //if (m_state == null)
               //{
               //     m_state = GetComponent<btn_state>();

               //}
               //m_state.m_state = _state;
          }

          private void fnp_change(string _state)
          {
               btn_changecolor t_cc = GetComponent<btn_changecolor>();
               if (t_cc != null)
               {
                    t_cc.fn_change(_state);
               }
          }

          public override void fn_off()
          {
               if (m_handle == null)
               {
                    m_handle = GetComponent<AB_HandleEvent>();

               }
               StateValueString t_value = (StateValueString)m_handle.fn_get("onoff");
               if (t_value.m_date == "on")
               {
                    fnp_change("off");
                    t_value.m_date = "off";
                    AB_Message t_msg = new N_Message();
                    t_msg.fn_init(E_MessageType.e_changeState,
                         new StateValue[1] { t_value }, "change");
                    m_handle.fn_HandleMsg(t_msg);
               }
          }



          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }


          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }
     }

}