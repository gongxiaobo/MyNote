using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
namespace GasPowerGeneration
{
     public class N_soundChain : AB_soundChain
     {
          int m_pos = 0;
          bool m_start = false;
          string[] m_chain;
          public override void fn_startChain(string[] _chain)
          {
               m_chain = _chain;
               if (m_chain == null)
               {
                    return;
               }
               if (m_chain.Length == 0)
               {
                    return;
               }
               if (m_start)
               {
                    return;
               }
               m_start = true;
               m_chain = _chain;
               //S_SoundComSingle.Instance.fnp_sound(m_chain[m_pos]);

               //float t_nextTime=S_SoundComSingle.Instance.fn_soundLength(m_chain[m_pos]);
               //t_nextTime-=0.15f;
               //m_pos++;
               //Invoke("fnp_playNext", t_nextTime >0f?t_nextTime:0.1f);

               //Debug.Log("<color=blue>播放声音链</color>");

               fnp_playNext();
          }
          protected virtual void fnp_playNext()
          {
               if (m_pos == m_chain.Length)
               {
                    S_SoundComSingle.Instance.fn_endSoundChain(m_chainname);
                    return;
               }
               S_SoundComSingle.Instance.fnp_sound(m_chain[m_pos]);

               float t_nextTime = S_SoundComSingle.Instance.fn_soundLength(m_chain[m_pos]);
               t_nextTime -= 0.15f;

               //Debug.Log("<color=red>red:</color>" + m_pos +"|"+ t_nextTime);

               m_pos++;
               Invoke("fnp_playNext", t_nextTime > 0f ? t_nextTime : 0.1f);

          }
          public override void fn_endChain()
          {
               if (m_start)
               {
                    CancelInvoke("fnp_playNext");
                    m_chain = null;
                    m_start = false;
                    Destroy(this);
                    Destroy(this.gameObject);
               }
          }
     }

}