using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_cdpselectpar : MonoBehaviour, I_Control
     {

          private N_HandleEvent_init handler;

          private void Start()
          {
               handler = GetComponent<N_HandleEvent_init>();
          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {

          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               StateValueString state = (StateValueString)handler.fn_get("floatvalue");
               state.m_date = _level.ToString();
               handler.fn_set(state);
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }
     }

}