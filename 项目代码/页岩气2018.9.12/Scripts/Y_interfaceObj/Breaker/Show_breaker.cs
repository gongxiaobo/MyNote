using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class Show_breaker : MonoBehaviour, I_Control
     {

          private N_handle handle;
          private void Start()
          {
               handle = GetComponentInChildren<N_handle>();
          }



          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    handle.fn_setTo(0);
               }
               else
                    handle.fn_setTo(0);
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    handle.fn_setTo(1);
               }
               else
                    handle.fn_setTo(1);
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_level(float _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
               //switch (_txt)
               //{
               //    case "on":
               //        print(gameObject.name + "  on");
               //        handle.fn_setTo(0);
               //        break;
               //    case "off":
               //        print(gameObject.name + "  off");
               //        handle.fn_setTo(1);
               //        break;
               //    default:
               //        break;
               //}
          }


          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
          }
     }

}