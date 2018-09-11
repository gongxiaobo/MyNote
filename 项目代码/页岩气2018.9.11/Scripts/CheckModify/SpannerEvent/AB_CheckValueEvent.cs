using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 主要用于旋钮的值到达一定位置后的事件通知
     /// </summary>
     public abstract class AB_CheckValueEvent : MonoBehaviour
     {
          /// <summary>
          /// 旋钮在结束控制后的事件
          /// </summary>
          /// <param name="_now">当前的旋转值</param>
          /// <param name="_valuelimit">旋钮的范围值</param>
          public abstract void fn_ValueEvent(float _now, Vector2 _valuelimit);
     } 
}
