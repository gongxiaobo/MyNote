using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 接电模式下，射线高亮的实现
     /// </summary>
     public class WireLightTrigger : A_TriggerObj
     {
          protected AB_LightOneObj m_lightOneObj;
          protected I_lightChangeMat mi_lightchange;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (m_lightOneObj==null)
               {
                    m_lightOneObj = GetComponent<AB_LightOneObj>();
               }
               if (mi_lightchange==null)
               {
                    mi_lightchange = GetComponent<I_lightChangeMat>();
               }
               if (_button== E_buttonIndex.e_padTouched)
               {
                    if (mi_lightchange!=null)
                    {
                         mi_lightchange.fni_changeColor(E_lightObjColor.e_red); 
                    }
                    if (m_lightOneObj!=null)
                    {
                         m_lightOneObj.fn_light(); 
                    }
                   
               }
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    S_SoundComSingle.Instance.fnp_sound("sure");
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    if (m_lightOneObj!=null)
                    {
                         m_lightOneObj.fn_endLigth(); 
                    }
               }
          }

          
     } 
}
