using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Show_light : MonoBehaviour, I_Control
     {


          private ParticleSystem light;
          private N_HandleEvent_init handler;
          // Use this for initialization
          void Start()
          {
               light = GetComponentInChildren<ParticleSystem>();
               handler = GetComponent<N_HandleEvent_init>();
          }


          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    if (light != null)
                         light.Play();

               }
               else
               {

                    if (light != null)
                         light.Play();


               }
               StateValueString state;
               if (handler != null)
               {
                    state = (StateValueString)handler.fn_get("onoff");
                    state.m_date = "on";
                    handler.fn_set(state);
               }

          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    if (light != null)
                         light.Stop();
               }
               else
               {
                    if (light != null)
                         light.Stop();

               }
               StateValueString state;
               if (handler != null)
               {
                    state = (StateValueString)handler.fn_get("onoff");
                    state.m_date = "off";
                    handler.fn_set(state);
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
               //Debug.Log("<color=blue>light:</color>" + _statename + "=" + _value);
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