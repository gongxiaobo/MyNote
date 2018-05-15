using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_param_pointer : AB_Param
     {


          private N_Pointer pointer;
          float m_level = 10f;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               pointer = GetComponentInChildren<N_Pointer>();
          }
          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    pointer.fn_inputValue(_level);
               }
               else
               {
                    pointer.fn_inputValue(_level);
               }
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("level", _level.ToString(), GetComponent<AB_HandleEvent>());
          }

          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    //pointer.fn_inputValue(_level);
                    pointer.fn_inputValue(_level);
               }
               else
               {
                    pointer.fn_inputValue(_level);
               }
               AB_SetState t_set = new N_SetState();
               t_set.fn_setState("floatvalue", _level.ToString(), GetComponent<AB_HandleEvent>());
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         fni_level(m_level);
                    }
                    else
                    {
                         fni_level(0f);
                    }
               }
          }
     }

}