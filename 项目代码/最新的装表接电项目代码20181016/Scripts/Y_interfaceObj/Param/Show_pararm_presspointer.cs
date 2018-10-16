using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_pararm_presspointer : AB_Param
     {

          private N_Pointer pointer;
          float m_level = 10f;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               pointer = GetComponentInChildren<N_Pointer>();
          }

          public override void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               pointer.fn_inputValue(m_level);
          }

          public override void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               pointer.fn_inputValue(0);
          }

          public override void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               m_level = _level;
          }

          public override void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               m_level = _level;
          }
          public override void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_statename == "electric")
               {
                    if (_value == "con")
                    {
                         pointer.fn_inputValue(m_level);
                    }
                    else
                    {
                         pointer.fn_inputValue(0);
                    }
               }
          }
     }

}