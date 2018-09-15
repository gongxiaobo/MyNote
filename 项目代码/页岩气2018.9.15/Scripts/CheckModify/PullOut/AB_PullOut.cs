using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 拉出物体的抽象
     /// </summary>
     public abstract class AB_PullOut : MonoBehaviour, I_PullOutTrigger
     {
          /// <summary>
          /// 激活
          /// </summary>
          public abstract void fn_activation();
          /// <summary>
          /// 拉出物体
          /// </summary>
          public abstract void fn_PullOut();
          /// <summary>
          /// 要拉出的物体引用
          /// </summary>
          public abstract GameObject M_PullObj { get; set; }
          /// <summary>
          /// 再次激活触发器
          /// </summary>
          /// <param name="_onoff"></param>
          public abstract void fn_Trigger(bool _onoff);
          /// <summary>
          /// 放回到机器的触发器显示和隐藏
          /// </summary>
          /// <param name="_onoff"></param>
          public abstract void fn_BackTrigger(bool _onoff);

          public virtual void fni_SetPartTrigger(bool _bl)
          {
          }
     } 
}
