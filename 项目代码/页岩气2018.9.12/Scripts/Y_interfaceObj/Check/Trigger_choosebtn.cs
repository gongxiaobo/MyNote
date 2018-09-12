using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace GasPowerGeneration
{
     /// <summary>
     /// 需检查物体确认按钮trigger类
     /// </summary>
     public class Trigger_choosebtn : A_TriggerObj
     {
          public event VoidDelegate onClick;
          public RectTransform recttrans;
          protected override void Start()
          {


               base.Start();
               recttrans = GetComponent<RectTransform>();
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               //if (_button == E_buttonIndex.e_triggerDown)
               //    onClick(gameObject);
               if (_button == E_buttonIndex.e_padTouched)
               {
                    recttrans.DOScale(new Vector3(1.2f, 1.2f), 0.1f);

               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    recttrans.DOScale(new Vector3(1f, 1f), 0.1f);
               }

               if (_button == E_buttonIndex.e_padPressDown)
               {
                    print("pressdown");
                    if (onClick != null)
                         onClick(gameObject);
               }
          }



     }

}