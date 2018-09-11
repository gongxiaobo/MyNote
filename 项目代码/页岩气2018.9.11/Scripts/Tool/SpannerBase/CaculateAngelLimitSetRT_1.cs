using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把，摇动时发出声音
     /// </summary>
     public class CaculateAngelLimitSetRT_1 : CaculateAngelLimitSetRT, I_setRotateSound
     {
          float m_anglevalue = 0f;
          public override void fn_startControl(Transform _hand)
          {
               base.fn_startControl(_hand);
               m_anglevalue = m_allRotate;
          }
          protected override void fnp_playSound()
          {
               base.fnp_playSound();
               bool t_play = false;
               //通过角度来播放声音
               if (m_allRotate-m_anglevalue>0f)
               {
                    if (m_allRotate-m_anglevalue>5f)
                    {
                         m_anglevalue += 5f;
                         t_play = true;
                    }
                    else
                    {

                    }
               }
               else
               {
                    if (m_allRotate - m_anglevalue < -5f)
                    {
                         m_anglevalue -= 5f;
                         t_play = true;
                    }
                    else
                    {

                    }
               }
               if (m_soundName != "" && t_play)
               {
                    S_SoundComSingle.Instance.fnp_sound(m_soundName);
               }
          }
          /// <summary>
          /// 碰触的物体在摇动时的声音名称
          /// </summary>
          string m_soundName = "";
          public void fni_SetSoundName(string _soundname)
          {
               m_soundName = _soundname ;
               if (m_soundName=="")
               {
                    m_anglevalue = 0f;
               }
          }
         
     } 
}
