using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_setting : N_handpanel
     {
          bool mute = true;
          int min;
          int sec;
          private Slider slider;
          protected override void Awake()
          {
               base.Awake();
               slider = GetComponentInChildren<Slider>();
               slider.value = 0.8f;
          }

          protected override void fn_btn_press(GameObject go, bool press)
          {
               base.fn_btn_press(go, press);
               if (!press) return;
               switch (go.name)
               {
                    case "btn_add":
                         slider.value += 0.1f;
                         S_SoundComSingle.Instance.fn_setAllSoundVolum(slider.value);

                         break;
                    case "btn_divide":
                         slider.value -= 0.1f;
                         S_SoundComSingle.Instance.fn_setAllSoundVolum(slider.value);
                         break;
                    case "btn_mute":
                         S_SoundComSingle.Instance.fn_shutSound(mute);
                         mute = !mute;
                         break;
               }
          }


     }

}