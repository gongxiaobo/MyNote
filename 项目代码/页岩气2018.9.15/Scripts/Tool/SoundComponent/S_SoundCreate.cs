#define addmixer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音的不销毁组件，子节点挂载所有的声音文件，整个程序运行期间不销毁
     /// 在程序开始加载一次所有的声音
     /// 给声音加载audiomixer
     /// </summary>
     public class S_SoundCreate : GenericDontDestroy<S_SoundCreate>
     {
          /// <summary>
          /// 声音的所有名称
          /// </summary>
          public string[] m_soundNames;
          bool m_isCreate = false;
          public void fn_createSoundCom(string[] _names)
          {
               fnp_getAudioMixer();

               if (m_isCreate)
               {
                    return;
               }
               m_isCreate = true;
               m_soundNames = _names;
               for (int i = 0; i < m_soundNames.Length; i++)
               {
                    GameObject t_sound = new GameObject(m_soundNames[i]);
                    t_sound.transform.parent = this.transform;
                    t_sound.transform.position = Vector3.zero;
                    AudioSource t_as = t_sound.AddComponent<AudioSource>();
                    S_FindVoice.Instance.fn_creatVoice(t_as, m_soundNames[i], null);
               }
               gameObject.AddComponent<N_WelcomeSound>();
          }
          /// <summary>
          /// 使用类型名称在加载声音后加上声音融合器
          /// </summary>
          public void fn_createSoundCom()
          {
               if (m_isCreate)
               {
                    return;
               }
               m_isCreate = true;
#if addmixer
               fnp_getAudioMixer();
#endif

               foreach (var _soundname in S_LoadTable.Instance.M_allsounds.Values)
               {
                    GameObject t_sound = new GameObject(_soundname.m_name);
                    t_sound.transform.parent = this.transform;
                    t_sound.transform.position = Vector3.zero;
                    AudioSource t_as = t_sound.AddComponent<AudioSource>();
                    S_FindVoice.Instance.fn_creatVoice(t_as, _soundname.m_name, null);
#if addmixer
                    if (_soundname.m_type == "")
                    {
                         fnp_setMixer(t_as, m_human);
                    }
                    else if (_soundname.m_type == "effect")
                    {
                         fnp_setMixer(t_as, m_effect);
                    }
                    else if (_soundname.m_type == "bg")
                    {
                         fnp_setMixer(t_as, m_bg);
                    }
#endif
               }
               gameObject.AddComponent<N_WelcomeSound>();
          }

          private void fnp_setMixer(AudioSource t_as, AudioMixerGroup _mixer)
          {
               t_as.outputAudioMixerGroup = _mixer;
          }
          #region findMixer
          protected AudioMixerGroup m_master, m_human, m_effect, m_bg;
          /// <summary>
          /// 主混合器
          /// </summary>
          public AudioMixerGroup Master
          {
               get { return m_master; }
               //set { m_master = value; }
          }
          /// <summary>
          /// 找到混合器
          /// </summary>
          protected void fnp_getAudioMixer()
          {
               if (m_master == null || m_human == null || m_effect == null || m_bg == null)
               {
                    AudioMixer t_audio = Resources.Load<AudioMixer>("AudioMixer");

                    if (t_audio != null)
                    {
                         foreach (var mixer in t_audio.FindMatchingGroups("Master"))
                         {

                              fnp_getMixerGroup(mixer);
                         }

                         Debug.Log("<color=blue>找到混合器</color>");
                    }
               }
          }
          private void fnp_getMixerGroup(AudioMixerGroup mixer)
          {
               switch (mixer.name)
               {
                    case "Master":
                         m_master = mixer;
                         break;
                    case "humansound":
                         m_human = mixer;
                         break;
                    case "effect":
                         m_effect = mixer;
                         break;
                    case "bg":
                         m_bg = mixer;
                         break;
                    default:
                         break;
               }
          }
          #endregion

     }

}