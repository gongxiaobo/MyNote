using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace GasPowerGeneration
{
     public class Show_bar : MonoBehaviour, I_Control, I_Showbar
     {
          bool show = false;
          private RectTransform rect;

          public float max;

          private float value;
          private Slider slider;
          private Text percent;
          // Use this for initialization
          void Start()
          {
               rect = TransformHelper.FindChild(transform, "Bar").GetComponent<RectTransform>();
               if (TransformHelper.FindChild(transform, "Slider") != null)
                    slider = TransformHelper.FindChild(transform, "Slider").GetComponent<Slider>();
               if (TransformHelper.FindChild(transform, "percent") != null)
                    percent = TransformHelper.FindChild(transform, "percent").GetComponent<Text>();
               HideBar();
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
               if (_controlType == E_ControlType.e_init)
               {
                    float temp = _level / max;
                    if (temp > 1)
                         temp = 1;
                    if (slider != null)
                    {
                         slider.value = temp;

                    }
                    if (percent != null)
                         percent.text = (temp * 100).ToString() + "%";
               }
          }

          public void fni_txt(string _txt, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void fni_stateChange(string _statename, string _value, E_ControlType _controlType = E_ControlType.e_normal)
          {
          }

          public void ShowBar()
          {
               if (show)
               {
                    HideBar();

               }
               else
               {
                    rect.DOScale(1, 0.3f);

               }
               show = !show;
          }


          public void HideBar()
          {
               rect.DOScale(0, 0.3f);
          }
     }

}