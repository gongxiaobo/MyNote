using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 工具的位置检查
     /// </summary>
     public abstract class AB_ToolDisCheck : MonoBehaviour
     {
          /// <summary>
          /// 检查距离
          /// </summary>
          public abstract void fn_check();
          /// <summary>
          /// 重置位置
          /// </summary>
          public abstract void fn_resetPos();
     } 
}
