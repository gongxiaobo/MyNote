using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 冒泡类型的显示值的转换
     /// </summary>
     public abstract class AB_BubbleKeyValue : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 开始加载资源
          /// </summary>
          protected abstract void fnp_load();
          /// <summary>
          /// 运行时通过state的mainvalue来找到单位或者名称
          /// 用于冒泡类型的显示
          /// </summary>
          /// <param name="_stateValue"></param>
          /// <returns></returns>
          public abstract string fn_getValue(string _stateValue);

     } 
}
