using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Trigger_line : A_TriggerObj
     {

          // Use this for initialization
          protected override void Start()
          {
               base.Start();
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (_inOut)
               {
                    print("发送数据给manager");
                    GetComponent<CheckUI>().fn_send_messagetomanager();
                    GetComponent<CheckUI>().fn_send_handpos(transform);
               }


          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {

          }
     }

}