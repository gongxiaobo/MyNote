using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 装表接电的高亮模式动态改变材质
     /// </summary>
     public interface I_lightChangeMat
     {
          /// <summary>
          /// 改变材质
          /// </summary>
          /// <param name="_colorName"></param>
          void fni_changeColor(E_lightObjColor _color);
          /// <summary>
          /// 获取当前的物体的颜色
          /// </summary>
          /// <returns></returns>
          E_lightObjColor fni_getColorNow();
     } 
}
