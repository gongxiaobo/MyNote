using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0223/ :加入可以循环播放的设置
     ///@ author gong
     ///@ version 1.1 /2017.0304/ :加入可以设置音效混合器的方法
     ///@ author gong
     ///@ version 1.2 /2017.0309/ :fns_resetAudio_loop 方法重载
     ///@ author gong
     ///@ version 1.3 /2017.0912/ :全部3d音效修改为2d音效
     ///@ author gong
     ///</summary>
     public static class S_SetAudioSource
     {
          /// <summary>
          /// 初始化3D音效
          /// 开始不播放
          /// 不循环播放
          /// 声音播放范围[1,10]m
          /// </summary>
          /// <param name="_Asource">Asource.</param>
          public static void fns_resetAudio(ref AudioSource _Asource)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = false;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

          }
          /// <summary>
          /// 初始化3D音效
          /// 开始不播放
          /// 不循环播放
          /// 声音播放范围[1,10]m
          /// 设置音效混合器
          /// </summary>
          /// <param name="_Asource">ref Asource.</param>
          /// <param name="_mixer">音效混合器</param>
          public static void fns_resetAudio(ref AudioSource _Asource, AudioMixerGroup _mixer)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = false;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

               if (_mixer != null)
               {
                    _Asource.outputAudioMixerGroup = _mixer;
               }

          }
          /// <summary>
          /// 初始化3D音效
          /// 开始不播放
          /// 循环播放
          /// 声音播放范围[1,10]m
          /// </summary>
          /// <param name="_Asource">ref Asource.</param>
          public static void fns_resetAudio_loop(ref AudioSource _Asource)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = true;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

          }

          /// <summary>
          /// 初始化3D音效
          /// 开始不播放
          /// 循环播放
          /// 声音播放范围[1,10]m
          /// 加入音效混合器
          /// </summary>
          /// <param name="_Asource">ref Asource.</param>
          public static void fns_resetAudio_loop(ref AudioSource _Asource, AudioMixerGroup _mixer)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = true;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;
               if (_mixer != null)
               {
                    _Asource.outputAudioMixerGroup = _mixer;
               }
          }
          /// <summary>
          /// 初始化2D音效
          /// 开始不播放
          /// 不循环播放
          /// 声音播放范围[1,100]m
          /// 设置音效混合器
          /// </summary>
          /// <param name="_Asource">ref Asource.</param>
          /// <param name="_mixer">音效混合器</param>
          public static void fns_resetAudio_No3D(ref AudioSource _Asource, AudioMixerGroup _mixer)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = false;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

               if (_mixer != null)
               {
                    _Asource.outputAudioMixerGroup = _mixer;
               }

          }
          public static void fns_resetAudio_No3D(AudioSource _Asource, AudioMixerGroup _mixer)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = false;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

               if (_mixer != null)
               {
                    _Asource.outputAudioMixerGroup = _mixer;
               }

          }
          public static void fns_resetAudio_No3DLoop(AudioSource _Asource, AudioMixerGroup _mixer)
          {
               _Asource.playOnAwake = false;
               _Asource.loop = true;
               _Asource.spatialBlend = 0;
               _Asource.minDistance = 1;
               _Asource.maxDistance = 100;

               if (_mixer != null)
               {
                    _Asource.outputAudioMixerGroup = _mixer;
               }

          }

     }

}