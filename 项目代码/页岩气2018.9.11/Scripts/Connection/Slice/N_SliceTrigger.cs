using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 划片的手柄触发器
     /// </summary>
     public class N_SliceTrigger : A_TriggerObj
     {
          protected AB_LightOneObj m_lightOneObj;
          I_OnOffTrigger mi_OnOffTrigger = null;
          protected override void Start()
          {
               base.Start();
               if (mi_OnOffTrigger == null)
               {
                    mi_OnOffTrigger = GetComponent<I_OnOffTrigger>();
               }
               if (m_lightOneObj == null)
               {
                    m_lightOneObj = GetComponent<AB_LightOneObj>();
               }
               if (m_lightOneObj == null)
               {
                    m_lightOneObj = GetComponentInChildren<AB_LightOneObj>();
               }
          }
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {

               if (_button == E_buttonIndex.e_padTouched)
               {
                    
                    if (m_lightOneObj != null)
                    {
                         m_lightOneObj.fn_light();
                    }
                    S_SoundComSingle.Instance.fnp_sound("rayhit");
               }
              
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    if (m_lightOneObj != null)
                    {
                         m_lightOneObj.fn_endLigth();
                    }
               }
               if (_button== E_buttonIndex.e_padPressDown)
               {
                    if (mi_OnOffTrigger != null)
                    {
                         mi_OnOffTrigger.fni_OnOffTrigger();
                    }
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
          }
     } 
}
