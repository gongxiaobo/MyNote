using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testHand : A_TriggerObj
     {
          public CaculateAngel mca;
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (_inOut)
               {
                    if (mca != null)
                    {
                         mca.fn_startControl(
                              S_HandButton.Instance.GetRigid.fni_getHandRigid().transform);
                         AB_LightOneObj t_light = GetComponent<AB_LightOneObj>();
                         if (t_light != null)
                         {
                              t_light.fn_endLigth();
                         }
                    }
               }
               else
               {
                    if (mca != null)
                    {
                         mca.fn_endControl();
                         AB_LightOneObj t_light = GetComponent<AB_LightOneObj>();
                         if (t_light != null)
                         {
                              t_light.fn_light();
                         }
                    }
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               //if (_button== E_buttonIndex.e_triggerDown)
               //{
               //     if (mca!=null)
               //     {
               //          mca.fn_startControl(_hand.fni_getHandRigid().transform);
               //     }
               //}
               //if (_button== E_buttonIndex.e_triggerUp)
               //{
               //     if (mca != null)
               //     {
               //          mca.fn_endControl();
               //     }
               //}
          }
     }

}