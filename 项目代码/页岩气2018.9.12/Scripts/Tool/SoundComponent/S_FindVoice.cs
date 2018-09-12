using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0218/ :用于动态创建语音
     ///@ author gong
     ///@ version 1.1 /2017.0227/ :原本只能一次加载一个音效,修改为请求缓存，可以同时相应多个请求fnp_DoNext()
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class S_FindVoice : GenericSingletonClass<S_FindVoice>
     {

          //	// Use this for initialization
          //	void Start () {
          //	
          //	}
          //	
          //	// Update is called once per frame
          //	void Update () {
          //	
          //	}
          private WWW www;
          private string url;

          /// <summary>
          /// 找到音效路径
          /// </summary>
          private void fn_findSound()
          {
               url = "file://";
               //string []t_strArray=Application.dataPath.Split('/');
               //for (int i = 0; i < t_strArray.Length - 1; i++) {
               //     url += (t_strArray [i] + "/");
               //}
               url += S_setting.m_pathSound;
               //url+="/sound/";
          }
          /// <summary>
          /// 外部文件夹加载对应名字的音效
          /// </summary>
          /// <returns>The load movie.</returns>
          private IEnumerator DownLoadMovie()
          {
               url += (t_voice + ".ogg");//本地音效
               Debug.Log(url);
               www = new WWW(url);
               yield return www;
               if (www.error == null)
               {

                    if (www.GetAudioClip(true, true) != null)
                    {

                         if (t_Source != null)
                         {
                              t_Source.clip = www.GetAudioClip(true, true);
                         }
                         Debug.Log("找到音效资源");

                    }
                    else
                    {
                         t_Source.clip = null;
                         Debug.Log("找到音效资源格式不符合要求");
                    }

               }
               else
               {
                    t_Source.clip = null;
                    Debug.Log("<color=red>没有找到音效资源</color>" + "-->" + t_voice);
               }
               if (t_action != null)
               {
                    t_action();
               }
               if (www != null)
               {
                    www.Dispose();
                    www = null;
               }


               fnp_DoNext();

          }

          /// <summary>
          /// 如果有缓存的请求，继续执行
          /// </summary>
          private void fnp_DoNext()
          {
               m_isDownLoading = false;

               if (m_voiceQueue.Count > 0)
               {
                    N_VoiceQueue t_voicequeue = m_voiceQueue.Dequeue();
                    if (t_voicequeue != null)
                    {
                         fn_creatVoice(t_voicequeue.T_Source, t_voicequeue.T_voice, t_voicequeue.T_action);
                    }
                    t_voicequeue = null;
               }
          }
          private AudioSource t_Source;
          private Action t_action;
          private String t_voice;
          //语音请求发缓存
          private Queue<N_VoiceQueue> m_voiceQueue = new Queue<N_VoiceQueue>();
          /// <summary>
          /// 获取队列的数量
          /// </summary>
          /// <returns></returns>
          public int fn_QueueNum()
          {
               return m_voiceQueue.Count;
          }
          //是否正在下载语音
          private bool m_isDownLoading = false;

          /// <summary>
          /// 创建音效
          /// </summary>
          /// <param name="_source">Source.</param>
          /// <param name="_voiceName">Voice name.</param>
          /// <param name="_callback">Callback.</param>
          public void fn_creatVoice(AudioSource _source, string _voiceName, Action _callback)
          {
               if (m_isDownLoading == true)
               {//如果正在下载音效，先缓存命令
                    m_voiceQueue.Enqueue(new N_VoiceQueue(_source, _voiceName, _callback));
                    return;
               }

               m_isDownLoading = true;
               if (_source != null)
               {//如果已经有音效就取消关联音效，重新加载新的音效			
                    if (_source.clip != null)
                    {
                         _source.clip = null;
                    }
               }

               t_Source = _source;
               t_action = null;
               t_action = _callback;
               t_voice = _voiceName;
               if (t_Source == null || _voiceName == "")
               {
                    return;
               }
               fn_findSound();//找到路径
               StartCoroutine(DownLoadMovie());

          }

     }

     ///<summary>
     ///@ version 1.0 /2017.0227/ :下载语音的保存数据
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class N_VoiceQueue
     {
          private AudioSource t_Source;
          public AudioSource T_Source { get { return t_Source; } }
          private Action t_action;
          public Action T_action { get { return t_action; } }
          private String t_voice;
          public String T_voice { get { return t_voice; } }

          public N_VoiceQueue(AudioSource _source, string _voiceName, Action _callback)
          {

               t_Source = _source;
               t_action = _callback;
               t_voice = _voiceName;
          }
     }

}