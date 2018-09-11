using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_grouplight : MonoBehaviour, I_Control
     {

          public GameObject on_light;
          public GameObject off_light;
          private N_HandleEvent_init handler;

          // Use this for initialization
          void Start()
          {
               handler = GetComponent<N_HandleEvent_init>();

          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    on_light.SetActive(true);
                    off_light.SetActive(false);
               }
               else
               {
                    off_light.SetActive(false);
                    on_light.SetActive(true);
                    StateValueString t_value = (StateValueString)handler.fn_get("level");
                    if (t_value != null)
                    {
                         t_value.m_date = "1";
                         handler.fn_set(t_value);
                    }
               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    off_light.SetActive(true);
                    on_light.SetActive(false);
               }
               else
               {
                    on_light.SetActive(false);
                    off_light.SetActive(true);
                    StateValueString t_value = (StateValueString)handler.fn_get("level");
                    if (t_value != null)
                    {
                         t_value.m_date = "2";
                         handler.fn_set(t_value);
                    }
               }
          }

          public void fn_uncon(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    on_light.SetActive(false);
                    off_light.SetActive(false);
               }
               else
               {
                    on_light.SetActive(false);
                    off_light.SetActive(false);
                    StateValueString t_value = (StateValueString)handler.fn_get("level");
                    if (t_value != null)
                    {
                         t_value.m_date = "0";
                         handler.fn_set(t_value);
                    }
               }
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               switch (_level)
               {
                    case 1:
                         fni_on(_controlType);
                         break;
                    case 2:
                         fni_off(_controlType);
                         break;
                    case 0:
                         fn_uncon(_controlType);
                         break;
               }
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
                         fni_off(_controlType);
                    }
                    else
                    {
                         fn_uncon(_controlType);
                    }
               }
          }
     }

}