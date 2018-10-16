using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     public class Panel_setting : N_handpanel
     {
         public Sprite spr_mute;
         public Sprite spr_unmute;
         private Image image_mute;
          bool mute = false;
          int min;
          int sec;
          private Slider slider;
          protected override void Awake()
          {
               base.Awake();
               slider = GetComponentInChildren<Slider>();
               slider.value = 0.8f;
               image_mute = TransformHelper.FindChild(transform, "btn_mute").GetComponent<Image>();
               fn_change_mute_icon(mute);
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
                        
                        
                         mute = !mute;
                         S_SoundComSingle.Instance.fn_shutSound(mute);
                         fn_change_mute_icon(mute);
                         break;
               }
          }

          private void fn_change_mute_icon(bool mute) {
              if (mute)
              {
                  image_mute.sprite = spr_mute;
              }
              else {
                  image_mute.sprite = spr_unmute;
              }
          }

     }

}