using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 主要是物体的高亮接口，用于步骤提示
     /// </summary>
     public interface I_LightItem
     {
          /// <summary>
          /// 高亮
          /// </summary>
          void fni_lightOn();
          /// <summary>
          /// 关闭高亮
          /// </summary>
          void fni_endLight();

     } 
}
