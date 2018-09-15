using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public interface I_SetMovePara
     {
          /// <summary>
          /// 设置拉出器的移动间隔和移动距离
          /// </summary>
          /// <param name="_speed">敲打一次拉出的距离</param>
          /// <param name="_length">可以拉出的全部长度</param>
          void fni_set(float _speed,float _length);
     } 
}
