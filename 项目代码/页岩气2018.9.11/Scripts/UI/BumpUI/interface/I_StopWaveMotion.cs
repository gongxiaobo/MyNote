using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 停止当前的波动值功能
     /// </summary>
     public interface I_StopWaveMotion
     {
          /// <summary>
          /// 停止波动功能
          /// </summary>
          void fni_StopMotion();
          /// <summary>
          /// 开始波动功能
          /// </summary>
          void fni_StartMotion();
     } 
}
