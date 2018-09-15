using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_screen : MonoBehaviour, I_Control
     {

          private GameObject screen;
          private N_HandleEvent_init handler;
          // Use this for initialization
          void Start()
          {
               screen = transform.GetChild(0).gameObject;
               handler = GetComponent<N_HandleEvent_init>();
          }


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {

                    screen.SetActive(true);

               }

               else
               {
                    if (screen != null)
                         screen.SetActive(true);
                    StateValueString state;
                    if (handler != null)
                    {
                         state = (StateValueString)handler.fn_get("onoff");
                         state.m_date = "on";
                         handler.fn_set(state);
                    }
               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    if (screen != null)
                    {
                         screen.SetActive(false);
                    }
               }
               else
               {
                    if (screen != null)
                         screen.SetActive(false);
                    StateValueString state;
                    if (handler != null)
                    {
                         state = (StateValueString)handler.fn_get("onoff");
                         state.m_date = "off";
                         handler.fn_set(state);
                    }
               }
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
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         fni_on();
                    }
                    else
                    {
                         fni_off();
                    }
               }
          }
     }

}