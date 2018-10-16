using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 设置一个触发类型的动画播放
     /// </summary>
     public abstract class AB_AnimatorControl : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          public abstract void fn_Trigger(string _trigger);
          /// <summary>
          /// 重置状态
          /// </summary>
          public abstract void fn_Reset();
     } 
}
