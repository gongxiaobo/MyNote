using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 控制一个动画的自动累加动画
     /// </summary>
     public abstract class AB_AnimationAdd : MonoBehaviour
     {
          /// <summary>
          /// 动画开始自动累加的起始时间点
          /// </summary>
          public abstract float M_AniStartTime { get; set; }
          /// <summary>
          /// 增加间隔时间
          /// </summary>
          public abstract float M_AddSpace { get; set; }
          /// <summary>
          /// 现在的动画时间
          /// </summary>
          public abstract float M_AniTimeNow { get; set; }
          /// <summary>
          /// 开始累加动画
          /// </summary>
          public abstract void fn_StartAddAni();
          /// <summary>
          /// 结束播放动画
          /// </summary>
          public abstract void fn_EndAddAni();
          /// <summary>
          /// 设置动画的最大值
          /// </summary>
          public abstract float M_SetEndAniTime { get; set; }
          /// <summary>
          /// 动画值是否到达制动目标位置
          /// </summary>
          /// <returns></returns>
          public abstract bool fn_MoveToEnd();
     } 
}
