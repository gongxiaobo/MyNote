using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_handfuse : MonoBehaviour, I_Control
     {

          private Hand_handler_fuse handle;
          private AB_HandleEvent m_handle;
          private void Start()
          {
               handle = GetComponentInChildren<Hand_handler_fuse>();
               m_handle = GetComponent<AB_HandleEvent>();
          }


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    handle.SetState(handfusestate.connect);
                    handle.fuseposchange(true);
               }
               else
               {
                    StateValueString t_value = (StateValueString)m_handle.fn_get("onoff");

                    print("开启连接");
                    t_value.m_date = "on";
                    //m_handle.fn_set(t_value);
                    AB_Message message = new N_Message();
                    message.fn_init(E_MessageType.e_outside, new StateValue[1] { t_value }, "", m_handle.ID.m_ID);
                    m_handle.fn_HandleMsg(message);
               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    handle.SetState(handfusestate.disconnect);
                    handle.fuseposchange(false);
               }
               else
               {
                    StateValueString t_value = (StateValueString)m_handle.fn_get("onoff");

                    print("断开连接");
                    t_value.m_date = "off";
                    //m_handle.fn_set(t_value);
                    AB_Message message = new N_Message();
                    message.fn_init(E_MessageType.e_outside, new StateValue[1] { t_value }, "", m_handle.ID.m_ID);
                    m_handle.fn_HandleMsg(message);
               }

          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {

          }


          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }
     }

}