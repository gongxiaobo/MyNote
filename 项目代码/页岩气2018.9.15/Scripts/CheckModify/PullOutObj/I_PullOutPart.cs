using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 零件拿出机器后的事件接口
     /// </summary>
     public interface I_PullOutPart
     {
          /// <summary>
          /// 设置零件的触发器
          /// </summary>
          /// <param name="_bl"></param>
          void fni_setTrigger(bool _bl);

     } 
}
