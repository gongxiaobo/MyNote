using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Trigger_cdpscreen : A_TriggerObj
     {
          private I_Control screen;
          bool show;
          private CheckUI checkui;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               checkui = GetComponent<CheckUI>();
               if (checkui == null) checkui = GetComponentInParent<CheckUI>();
               screen = GetComponent<I_Control>();
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (_inOut)
               {
                    // print("发送数据给manager");
                    checkui.fn_send_messagetomanager();
                    checkui.fn_send_handpos(transform);
                    if (show == false)
                    {

                         screen.fni_on();
                         show = true;
                    }
                    else
                    {
                         screen.fni_off();
                         show = false;
                    }
               }


          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {

          }
     }

}