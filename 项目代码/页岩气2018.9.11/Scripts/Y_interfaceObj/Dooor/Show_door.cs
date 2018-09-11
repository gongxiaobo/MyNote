using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_door : MonoBehaviour, I_Control
     {




          private void fn_door_close()
          {
               transform.position = transform.Find("Close").position;
          }
          private void fn_door_open()
          {
               transform.position = transform.Find("Open").position;
          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    fn_door_open();
               }
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    fn_door_close();
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