using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 设置限制的接口
     /// </summary>
     public interface I_RealtimeSetRange
     {
          /// <summary>
          /// 设置限制范围
          /// </summary>
          /// <param name="_limitRange"></param>
          void fni_setRange(Vector2 _limitRange);
     }

}