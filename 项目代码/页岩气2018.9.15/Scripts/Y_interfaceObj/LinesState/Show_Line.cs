using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Show_Line : MonoBehaviour, I_Control
     {

          private Material mat;
          private AB_HandleEvent handler;
          // Use this for initialization

          //void OnGUI() {
          //    if (GUILayout.Button("确定正确"))
          //        fni_on();
          //}
          void Start()
          {
               mat = GetComponent<MeshRenderer>().material;
               handler = GetComponent<AB_HandleEvent>();
          }




          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               handler.fn_set(new StateValueString("check", "right"));
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               handler.fn_set(new StateValueString("check", "error"));
          }

          public void fni_level(int _level, E_ControlType _controlType = E_ControlType.e_normal)
          {
               if (_controlType == E_ControlType.e_init)
               {
                    switch (_level)
                    {
                         case 1:
                              mat.color = Color.white;
                              break;
                         case 2:
                              mat.color = Color.yellow;
                              break;
                         case 3:
                              mat.color = Color.green;
                              break;
                         case 4:
                              mat.color = Color.black;
                              break;
                         default:
                              break;
                    }
               }
               else
               {

               }
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