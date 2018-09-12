using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 需检查物体trigger类
     /// </summary>
     public class Trigger_check : A_TriggerObj
     {

          private CheckUI checkui;
          // Use this for initialization
          protected override void Start()
          {
               base.Start();
               checkui = GetComponent<CheckUI>();
               if (checkui == null) checkui = GetComponentInParent<CheckUI>();
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (_inOut)
               {
                    // print("发送数据给manager");
                    checkui.fn_send_messagetomanager();
                    checkui.fn_send_handpos(transform);
               }


          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {

          }
     } 
}