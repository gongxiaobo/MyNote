using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音抽象实现的抽象类
     /// @ version 1.0 20161130
     /// @ author gong
     /// </summary>
     public abstract class AB_SoundSource : AB_Sound
     {
          protected override void Start()
          {
               base.Start();
          }
          public sealed override void fn_playsound(string _name)
          {
               AudioSource t_AS = fnp_getSource(_name);
               if (t_AS != null)
               {
                    if (!t_AS.isPlaying)
                         t_AS.Play();
                    //			else
                    //				Debug.Log ("重复播放");
               }

          }
          public sealed override void fn_stopsound(string _name)
          {



               AudioSource t_AS = fnp_getSource(_name);
               if (t_AS != null)
               {
                    if (t_AS.isPlaying)
                         t_AS.Stop();
               }
          }
          public sealed override void fn_setVolum(string _name, float _volum)
          {
               AudioSource t_AS = fnp_getSource(_name);
               if (t_AS != null)
               {
                    t_AS.volume = _volum;
               }
          }
          public sealed override void fn_mut(bool _mut)
          {
               fnp_shutdown(_mut);
          }
          /// <summary>
          /// 根据名字获取相应的音乐源
          /// </summary>
          protected abstract AudioSource fnp_getSource(string _name);
          /// <summary>
          /// 关闭和开启所有这个节点的音效
          /// </summary>
          protected abstract void fnp_shutdown(bool _shut);


          public override void fn_setAllVolum(float _volum)
          {

          }
     }

}