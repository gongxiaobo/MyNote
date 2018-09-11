using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把类型，放入工具手开始计算旋转到什么情况下可以取下摇把
     /// </summary>
     public interface I_ToolPullOutLogic 
     {
          /// <summary>
          /// 摇把在什么时候可以拿出
          /// </summary>
          void fni_PullOutPos();
     } 
}
