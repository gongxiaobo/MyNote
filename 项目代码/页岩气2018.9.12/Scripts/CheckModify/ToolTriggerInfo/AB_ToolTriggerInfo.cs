using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 工具触发器，可以获取要控制的物体
     /// </summary>
     public abstract class AB_ToolTriggerInfo : MonoBehaviour
     {
          /// <summary>
          /// 获取工具现在要控制的物体
          /// </summary>
          /// <returns></returns>
          public abstract Transform fn_GetControlObj();
          /// <summary>
          /// 工具碰触器的显示和隐藏
          /// </summary>
          /// <param name="_show"></param>
          public abstract void fn_HideToolTrigger(bool _show = false);
          /// <summary>
          /// 工具物体
          /// 只要工具碰触到，就传入工具物体的引用
          /// </summary>
          public abstract GameObject M_ToolObj { get; set; }
     } 
}
