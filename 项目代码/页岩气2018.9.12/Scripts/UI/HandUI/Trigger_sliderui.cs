using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace GasPowerGeneration
{
     public class Trigger_sliderui : A_TriggerObj
     {

          public event VoidPressDelegate onPress;
          private Text text;

          Transform start_pos;

          protected override void Start()
          {
               base.Start();
               text = GetComponentInChildren<Text>();
               text.text = gameObject.name;
          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    start_pos = _hand.fni_getHand();
               }
               if (_button == E_buttonIndex.e_padPressUp)
               {

               }

          }



     }

}