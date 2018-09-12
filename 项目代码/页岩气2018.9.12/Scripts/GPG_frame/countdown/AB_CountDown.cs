using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 倒计时组件的抽象
     /// </summary>
     public abstract class AB_CountDown : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 开始倒计时，传入倒计时间，秒为单位
          /// </summary>
          /// <param name="_time"></param>
          public abstract void fn_startCountDown(float _time);
          /// <summary>
          /// 结束组件的倒计时
          /// </summary>
          public abstract void fn_endCountDown();
     } 
}
