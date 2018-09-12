using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 值到达边界的判断
     /// </summary>
     public interface I_ValueEdge
     {
          /// <summary>
          /// 如果值到达最大最小值就返回 true
          /// </summary>
          /// <returns></returns>
          bool fni_valueToEdge();
          bool fni_valueToBig();
          bool fni_valueToSmall();

     }
     public interface I_SpannerRotateValue : I_ValueEdge
     {
          /// <summary>
          /// 获取旋转的角度
          /// </summary>
          /// <returns></returns>
          float fni_getRotateValue();
          /// <summary>
          /// 获取旋钮的最大最小值
          /// </summary>
          /// <returns></returns>
          Vector2 fni_getLimit();

     } 
}
