using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 声音触发类型，开启时播放一个声音，关闭时不播放
     /// </summary>
     public class N_OnlyValue_SoundOnOff : N_OnlyValueLogic
     {
          /// <summary>
          /// 播放的声音
          /// </summary>
          public string m_soundName = "";
          protected override void fnp_On()
          {
               //base.fnp_On();
               S_SoundComSingle.Instance.fnp_sound(m_soundName);
          }
          protected override void fnp_Off()
          {
               //base.fnp_Off();
               S_SoundComSingle.Instance.fnp_sound(m_soundName, false);
          }
     } 
}
