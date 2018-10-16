using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 设置声音名称，
     /// 主要用于摇把在摇动的时候的声音播放
     /// </summary>
     public interface I_setRotateSound
     {
          /// <summary>
          /// 接口设置声音的名称
          /// </summary>
          /// <param name="_soundname"></param>
          void fni_SetSoundName(string _soundname);

     } 
}
