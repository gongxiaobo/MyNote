using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Show_textChange : MonoBehaviour, I_Control
     {

          private Text text;
          private float time_count = 5;
          // Use this for initialization
          void Start()
          {
               text = GetComponentInChildren<Text>();
          }

          public void fni_on(E_ControlType _controlType = E_ControlType.e_normal)
          {
               StartCoroutine(TimerCount());
          }

          public void fni_off(E_ControlType _controlType = E_ControlType.e_normal)
          {
               throw new System.NotImplementedException();
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
               throw new System.NotImplementedException();
          }
          IEnumerator TimerCount()
          {
               while (time_count > 0)
               {
                    yield return new WaitForSeconds(1);
                    text.text = "OK in " + time_count.ToString() + " seconds";
                    time_count--;
               }
               text.text = "back";
               StopCoroutine(TimerCount());

          }
     }

}