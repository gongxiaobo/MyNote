using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 倒计时类型的计算
     /// </summary>
     public abstract class AB_ColumnCount : MonoBehaviour
     {
          /// <summary>
          /// 开始倒计时
          /// </summary>
          public abstract void fn_StartCount();
          /// <summary>
          /// 
          /// </summary>
          /// <returns></returns>
          public abstract bool fn_IsEndCount();
          /// <summary>
          /// 重置
          /// </summary>
          public abstract void fn_reset();
     } 
}
