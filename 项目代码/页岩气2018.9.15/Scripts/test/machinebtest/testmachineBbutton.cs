using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// 手柄操作类
     /// </summary>
     public class testmachineBbutton : A_TriggerObj
     {


          private I_Control control;

          // Use this for initialization

          protected override void Start()
          {
               base.Start();
               control = GetComponent<I_Control>();

          }
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);

          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_triggerDown)
               {

               }

          }




     }

}