using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件的碰撞体隐藏和显示
     /// 只有显示了之后才能被操作
     /// </summary>
     public interface I_PullOutTrigger
     {
          /// <summary>
          /// 隐藏和显示触发器
          /// </summary>
          /// <param name="_bl"></param>
          void fni_SetPartTrigger(bool _bl);
     } 
}
