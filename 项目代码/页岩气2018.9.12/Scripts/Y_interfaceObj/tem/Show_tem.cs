using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GasPowerGeneration
{
     /// <summary>
     /// 指针类表盘显示类
     /// </summary>
     public class Show_tem : MonoBehaviour, I_Control
     {





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
               if (_controlType == E_ControlType.e_init)
               {
                    GetComponentInChildren<Text>().text = _level.ToString();
                    GetComponentInChildren<N_Pointer>().fn_inputValue(_level);
               }
               else
               {

               }
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