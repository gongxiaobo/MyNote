using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 判断一个零件在那个阶段使用工具
     /// </summary>
     public enum E_UseTool 
     {
          /// <summary>
          /// 不使用工具
          /// </summary>
          e_noUseTool=1,
          /// <summary>
          /// 在拿出零件使用工具
          /// </summary>
          e_UseToolFirst=2,
          /// <summary>
          /// 在放入零件使用工具
          /// </summary>
          e_UseToolLate=3,
          /// <summary>
          /// 在拿出放入都使用工具
          /// </summary>
          e_UseToolAll=4,
     } 
}
