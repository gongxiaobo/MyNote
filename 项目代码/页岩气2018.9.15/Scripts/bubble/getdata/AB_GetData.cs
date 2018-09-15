using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_GetData : MonoBehaviour
     {
          /// <summary>
          /// 显示数据
          /// </summary>
          public abstract void fn_showDate();
          /// <summary>
          /// 隐藏数据
          /// </summary>
          public abstract void fn_hideDtae();
          /// <summary>
          /// 获取数据
          /// </summary>
          protected abstract void fn_getDate();
     } 
}
