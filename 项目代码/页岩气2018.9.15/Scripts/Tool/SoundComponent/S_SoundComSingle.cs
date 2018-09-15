using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
//using GCode;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音主键的单例管理类
     /// 主要是关闭和开启作用
     /// @ version 1.0 20161130
     /// @ author gong
     /// </summary>
     public class S_SoundComSingle : GenericDontDestroy<S_SoundComSingle>
     {
          private List<AB_Sound> m_AB_Sound = new List<AB_Sound>();
          /// <summary>
          /// 声音组件的集合，可以通过名称找到
          /// </summary>
          protected Dictionary<string, AB_Sound> m_storeABSound = new Dictionary<string, AB_Sound>();

          public void fn_add(AB_Sound _soundSource)
          {
               if (_soundSource != null)
               {
                    m_AB_Sound.Add(_soundSource);
               }
          }
          public void fn_shutSound(bool _shut)
          {
               //foreach (AB_Sound _sound in m_AB_Sound) {
               //     _sound.fn_mut (_shut);
               //}
               S_SoundCreate.Instance.Master.audioMixer.SetFloat(
                    "MasterVolume", _shut ? -80f : m_SoundVolum);
          }
          float m_SoundVolum = 0f;
          /// <summary>
          /// 设置所有声音的音量
          /// -80-20
          /// </summary>
          /// <param name="_volum">0-1</param>
          public void fn_setAllSoundVolum(float _volum)
          {
               float t_change = Mathf.Clamp(_volum, 0f, 1f) * 100f - 80f;
               m_SoundVolum = t_change;

               S_SoundCreate.Instance.Master.audioMixer.SetFloat(
                    "MasterVolume", m_SoundVolum);
          }
          public void fn_add(string _soundName, AB_Sound _soundSource)
          {
               if (m_storeABSound != null)
               {
                    if (!m_storeABSound.ContainsKey(_soundName))
                    {
                         m_storeABSound.Add(_soundName, _soundSource);

                    }
               }
          }

          public AB_Sound fn_getABsound(string _soundname)
          {
               if (m_storeABSound.ContainsKey(_soundname))
               {
                    return m_storeABSound[_soundname];
               }
               return null;
          }
          /// <summary>
          /// 播放指定音效的播放和停止
          /// </summary>
          /// <param name="_Name">组件名称</param>
          /// <param name="_soundName">声音名称</param>
          /// <param name="_isPlay">播放或停止</param>
          public void fnp_sound(string _Name, string _soundName, bool _isPlay = true)
          {

               //Debug.Log("<color=blue>blue:</color>" + _soundName);

               if (m_storeABSound.ContainsKey(_Name))
               {
                    if (_isPlay)
                    {
                         m_storeABSound[_Name].fn_playsound(_soundName);
                         //Debug.Log("<color=blue>XXblue:</color>" + _soundName);
                    }
                    else
                    {
                         m_storeABSound[_Name].fn_stopsound(_soundName);
                    }
               }
          }
          protected string m_lastPlaySound = "";
          /// <summary>
          /// 页岩气项目的声音统一播放接口
          /// </summary>
          /// <param name="_soundName">声音的名称</param>
          /// <param name="_isPlay">true 为播放，默认 true</param>
          /// <param name="_Name">声音的管理节点名称，默认S_SoundCreate</param>
          public void fnp_sound(string _soundName, bool _isPlay = true, string _Name = "S_SoundCreate")
          {

               //Debug.Log("<color=blue>blue:</color>" + _soundName);

               if (m_storeABSound.ContainsKey(_Name))
               {
                    if (_isPlay)
                    {
                         //m_storeABSound[_Name].fn_stopsound(m_lastPlaySound);
                         m_storeABSound[_Name].fn_playsound(_soundName);
                         //m_lastPlaySound = _soundName;
                         //Debug.Log("<color=blue>XXblue:</color>" + _soundName);
                    }
                    else
                    {
                         m_storeABSound[_Name].fn_stopsound(_soundName);
                    }
               }
               else
               {
                    Debug.Log("<color=red>not find sound name :</color>" + _soundName);
               }
          }
          /// <summary>
          /// 播放一个声音，如果这个声音在播放的情况下，不打断这个声音的播放
          /// </summary>
          /// <param name="_soundName"></param>
          /// <param name="_isPlay"></param>
          /// <param name="_Name"></param>
          public void fnp_soundPlaying(string _soundName, bool _isPlay = true, string _Name = "S_SoundCreate")
          {

               //Debug.Log("<color=blue>blue:</color>" + _soundName);

               if (m_storeABSound.ContainsKey(_Name))
               {
                    if (_isPlay)
                    {

                         if ( m_storeABSound[_Name].fn_SoundIsPlaying(_soundName)==false)
                         {
                              m_storeABSound[_Name].fn_playsound(_soundName); 
                         }
                         
                    }
                    else
                    {
                         m_storeABSound[_Name].fn_stopsound(_soundName);
                    }
               }
               else
               {
                    Debug.Log("<color=red>not find sound name :</color>" + _soundName);
               }
          }
          /// <summary>
          /// 播放特殊声音，
          /// 包含多语言的切换
          /// </summary>
          /// <param name="_soundName">中文语音名称</param>
          /// <param name="_isPlay"></param>
          public void fnp_soundSpecial(string _soundName, bool _isPlay = true)
          {
               string t_lg = S_SceneMessage.Instance.fn_getLanguage();
               if (t_lg == "Chinese" || t_lg == "")
               {
                    fnp_sound(_soundName, _isPlay);
               }
               else
               {
                    if (S_LoadTable.Instance.M_specialsounds.ContainsKey(_soundName))
                    {
                         fnp_sound(S_LoadTable.Instance.M_specialsounds[_soundName].m_sound_e, _isPlay);
                    }

               }
               //if(S_SceneMagT1.Instance.m)

          }

          /// <summary>
          /// 声音链的缓存
          /// </summary>
          protected Dictionary<string, AB_soundChain> m_soundchain = new Dictionary<string, AB_soundChain>();
          /// <summary>
          /// 开始声音链的播放
          /// </summary>
          /// <param name="_names">播放声音顺序的名称数组</param>
          /// <param name="_chainname">声音链的名称，</param>
          public void fn_soundChain(string[] _names, string _chainname)
          {

               if (_names == null)
               {
                    return;
               }
               if (_names.Length == 0)
               {
                    return;
               }
               if (m_soundchain == null)
               {
                    m_soundchain = new Dictionary<string, AB_soundChain>();
               }
               if (m_soundchain.ContainsKey(_chainname))
               {
                    //如果相同的声音链，销毁以前的声音链
                    fn_endSoundChain(_chainname);
                    return;
               }
               //单独创建物体，在场景结束时销毁
               GameObject t_soundChain = new GameObject("_soundChain");
               m_soundchain.Add(_chainname, t_soundChain.AddComponent<N_soundChain>());
               m_soundchain[_chainname].m_chainname = _chainname;
               m_soundchain[_chainname].fn_startChain(_names);
          }
          /// <summary>
          /// 停止指定的声音链
          /// </summary>
          /// <param name="_chainname"></param>
          public void fn_endSoundChain(string _chainname)
          {
               if (m_soundchain.ContainsKey(_chainname))
               {
                    m_soundchain[_chainname].fn_endChain();
                    m_soundchain[_chainname] = null;
                    m_soundchain.Remove(_chainname);
               }
          }
          /// <summary>
          /// 场景结束时调用，停止还在播放的声音
          /// </summary>
          public void fn_killSoundChain()
          {

               if (m_storeABSound.ContainsKey("S_SoundCreate"))
               {
                    m_storeABSound["S_SoundCreate"].fn_stopAllSound();
               }
               if (m_soundchain.Count > 0)
               {
                    foreach (var item in m_soundchain.Values)
                    {
                         item.fn_endChain();

                    }
                    m_soundchain = null;
               }

          }

          /// <summary>
          /// 声音的长度
          /// </summary>
          /// <param name="_name"></param>
          /// <returns></returns>
          public float fn_soundLength(string _name, string _Name = "S_SoundCreate")
          {
               if (m_storeABSound.ContainsKey(_Name))
               {
                    return m_storeABSound[_Name].fn_getSoundLength(_name);
               }
               return 0f;
          }

     }

}