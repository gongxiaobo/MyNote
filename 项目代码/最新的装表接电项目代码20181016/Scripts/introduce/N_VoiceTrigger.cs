using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_VoiceTrigger : N_ScaleTarget
     {

          public N_showIntroduceOnUI m_introduceVoice = null;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (m_introduceVoice == null)
               {
                    Debug.Log("<color=blue>m_introduceVoice==null</color>");
                    return;
               }



               if (_button == E_buttonIndex.e_padPressDown)
               {
                    I_introduceVoice t_voice = (I_introduceVoice)m_introduceVoice;
                    if (t_voice != null)
                    {
                         t_voice.fni_introduceTrigger();
                    }
               }
          }

     } 
}
