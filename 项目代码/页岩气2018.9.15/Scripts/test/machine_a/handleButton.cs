using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class handleButton : A_TriggerObj
     {
          I_Control m_button = null;
          protected override void Start()
          {
               base.Start();
               m_button = GetComponent<I_Control>();
          }

          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    m_button.fni_on();
               }
               //if (_button == E_buttonIndex.e_triggerUp)
               //{

               //}
          }
     }

}