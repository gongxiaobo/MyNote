using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 测试射线交互
     /// </summary>
     public class testTrigger : A_TriggerObj
     {

          protected override void Start()
          {
               base.Start();

          }
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);

          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_padTouched)
               {

                    Debug.Log("<color=red>e_padTouched:</color>");

               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    Debug.Log("<color=red>e_padTouchOver:</color>");
               }


          }

     }

}