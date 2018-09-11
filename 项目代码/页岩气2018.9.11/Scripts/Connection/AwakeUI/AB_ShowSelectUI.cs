using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 显示选择电线的UI
     /// </summary>
     public abstract class AB_ShowSelectUI : MonoBehaviour
     {
          /// <summary>
          /// 显示选择UI
          /// </summary>
          public abstract void fn_showUI();
          /// <summary>
          /// 隐藏选择UI
          /// </summary>
          public abstract void fn_hideUI();
          /// <summary>
          /// 触发类型
          /// </summary>
          public abstract void fn_trigger();
       
     } 
}
