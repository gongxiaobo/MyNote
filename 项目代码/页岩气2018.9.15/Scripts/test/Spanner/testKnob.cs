using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testKnob : A_TriggerObj
     {

          public AB_Spanner mca;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (mca == null)
               {
                    mca = GetComponent<AB_Spanner>();
               }
               if (_button == E_buttonIndex.e_triggerDown)
               {
                    if (t_light != null)
                    {
                         t_light.fn_endLigth();
                    }
                    if (t_btnTip != null)
                    {
                         t_btnTip.fn_endLight();
                    }
                    if (m_btnActionTip != null)
                    {
                         m_btnActionTip.fn_endLight();
                    }
                    if (mca != null)
                    {
                         mca.fn_startControl(_hand.fni_getHandRigid().transform);
                    }
               }
               if (_button == E_buttonIndex.e_triggerUp)
               {
                    if (mca != null)
                    {
                         mca.fn_endControl();
                    }
               }
          }
          AB_LightOneObj t_light;
          AB_BtnTip t_btnTip;
          AB_BtnActionTip m_btnActionTip;
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (t_light == null)
               {
                    t_light = GetComponent<AB_LightOneObj>();
               }
               if (t_btnTip == null)
               {
                    t_btnTip = GetComponent<AB_BtnTip>();
               }
               if (m_btnActionTip == null)
               {
                    m_btnActionTip = GetComponent<AB_BtnActionTip>();
               }

               if (_inOut)
               {
                    if (t_light != null)
                    {
                         t_light.fn_light();
                    }
                    if (t_btnTip != null)
                    {
                         t_btnTip.fn_light();
                    }
                    if (m_btnActionTip != null)
                    {
                         m_btnActionTip.fn_light();
                    }
                    //
                    if (S_handShake.Instance.HandShake != null)
                    {
                         S_handShake.Instance.HandShake();
                    }
               }
               else
               {
                    if (t_light != null)
                    {
                         t_light.fn_endLigth();
                    }
                    if (t_btnTip != null)
                    {
                         t_btnTip.fn_endLight();
                    }
                    if (m_btnActionTip != null)
                    {
                         m_btnActionTip.fn_endLight();
                    }
               }

          }
     }

}