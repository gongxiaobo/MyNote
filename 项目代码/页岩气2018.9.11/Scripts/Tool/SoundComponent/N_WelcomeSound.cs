using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
namespace GasPowerGeneration
{

     /// <summary>
     ///  gong -- 2017/9/11
     ///  ***教学场景的欢迎语音
     ///  gong -- 2017/8/
     ///  ***
     ///  gong -- 2017/8/
     ///  ***
     ///  gong -- 2017/8/
     ///  ***
     /// </summary>
     public class N_WelcomeSound : AB_SoundSource
     {

          public AudioMixerGroup m_mixer = null;
          /// <summary>
          /// 混音集合
          /// </summary>
          public AudioMixerGroup[] m_mixerList;
          protected Dictionary<string, AudioSource> m_audioSource = new Dictionary<string, AudioSource>();

          protected override void Start()
          {
               base.Start();
               AudioSource[] t_as = gameObject.GetComponentsInChildren<AudioSource>(true);
               if (t_as.Length == 0)
               {
                    Destroy(this);
                    return;
               }
               for (int i = 0; i < t_as.Length; i++)
               {
                    if (!m_audioSource.ContainsKey(t_as[i].gameObject.name))
                    {
                         m_audioSource.Add(t_as[i].gameObject.name, t_as[i]);
                    }
                    else
                    {

                         Debug.Log("<color=red>exist the same name !</color>");
                    }
               }
               t_as = null;


               fnp_setAudio();
               S_SoundComSingle.Instance.fn_add(this);
               S_SoundComSingle.Instance.fn_add(this.gameObject.name, this);
          }
          /// <summary>
          /// 设置音源的初始化
          /// </summary>
          protected virtual void fnp_setAudio()
          {
               //if (m_mixer==null)
               //{
               //     return;
               //}
               foreach (var item in m_audioSource.Values)
               {
                    if (fnp_isSetLoop(item.name) == false)
                    {
                         S_SetAudioSource.fns_resetAudio_No3D(item, m_mixer);
                    }
                    else
                    {
                         S_SetAudioSource.fns_resetAudio_No3DLoop(item, m_mixer);
                    }
               }
          }
          protected bool fnp_isSetLoop(string _soundname)
          {
               switch (_soundname)
               {
                    case "gas_engine_run":
                    case "wind_machine_big":
                    case "backsound01":
                         return true;
                    default:
                         return false;
               }
          }

          protected override AudioSource fnp_getSource(string _name)
          {

               switch (_name)
               {
                    case "welcome":
                         return m_audioSource[gameObject.name];
                    case "startTest":
                         return m_audioSource["startTest"];
                    case "endTest":
                         return m_audioSource["endTest"];
                    case "startTrain":
                         return m_audioSource["startTrain"];
                    case "endTrain":
                         return m_audioSource["endTrain"];
                    default:
                         if (m_audioSource.ContainsKey(_name))
                         {
                              return m_audioSource[_name];
                         }
                         else
                         {
                              return null;
                         }

               }



          }
          protected override void fnp_shutdown(bool _shut)
          {
               //if (m_sound != null)
               //{
               //     m_sound.mute = _shut;
               //}
               foreach (var item in m_audioSource.Values)
               {
                    item.mute = _shut;
               }
          }
          public override void fn_setAllVolum(float _volum)
          {
               base.fn_setAllVolum(_volum);
               foreach (var item in m_audioSource.Values)
               {
                    item.volume = _volum;
               }
          }
          public override float fn_getSoundLength(string _name)
          {


               if (m_audioSource.ContainsKey(_name))
               {
                    if (m_audioSource[_name].clip != null)
                    {
                         return m_audioSource[_name].clip.length;
                    }
               }
               return 0f;
          }
          public override void fn_stopAllSound()
          {
               base.fn_stopAllSound();
               foreach (var _audio in m_audioSource.Values)
               {
                    if (_audio.isPlaying)
                    {
                         _audio.Stop();
                    }
               }

          }

     }

}