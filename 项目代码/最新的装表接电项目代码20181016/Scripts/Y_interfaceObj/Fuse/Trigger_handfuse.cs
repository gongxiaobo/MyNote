using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器trigger类
     /// </summary>
     public class Trigger_handfuse : A_TriggerObj
     {

          protected override void Start()
          {
               base.Start();

          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    GetComponent<I_holdobj>().StartHold(_hand.fni_getHandRigid().transform);
               }
          }
     }

}