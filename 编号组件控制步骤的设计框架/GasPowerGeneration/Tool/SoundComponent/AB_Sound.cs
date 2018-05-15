using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音播放组件抽象
     /// @ version 1.0 20161130
     ///           1.1 20161130 加入了fn_stopsound（），fn_setVolum（），fn_mut（），
     /// @ auhtor gong
     /// </summary>
     public abstract class AB_Sound : MonoBehaviour
     {
          //	public string m_soundname;
          // Use this for initialization
          protected virtual void Start()
          {
               //		gameObject.AddComponent<AudioSource> ();
          }
          /// <summary>
          /// 根据名字播放声音
          /// </summary>
          public abstract void fn_playsound(string _name);
          /// <summary>
          /// 根据名字停止声音
          /// </summary>
          /// <param name="_name">Name.</param>
          public abstract void fn_stopsound(string _name);
          /// <summary>
          /// 根据名字设置音量
          /// </summary>
          /// <param name="_volum">Volum.</param>
          public abstract void fn_setVolum(string _name, float _volum);
          public abstract void fn_setAllVolum(float _volum);
          /// <summary>
          /// 静音
          /// </summary>
          public abstract void fn_mut(bool _mut);
          /// <summary>
          /// 获取声音的长度
          /// </summary>
          /// <param name="_name"></param>
          /// <returns></returns>
          public virtual float fn_getSoundLength(string _name)
          {
               //Debug.Log("<color=blue>获取声音时间0:</color>" + _name);
               return 0;
          }
          public virtual void fn_stopAllSound() { }
          // Update is called once per frame
          //	void Update () {
          //	
          //	}
     }

}