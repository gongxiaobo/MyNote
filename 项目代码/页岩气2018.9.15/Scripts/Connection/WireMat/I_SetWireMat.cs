using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 设置电线的默认材质
     /// </summary>
     public interface I_SetWireMat
     {
          /// <summary>
          /// 设置电线的默认材质，主要用于电线颜色的设置
          /// </summary>
          /// <param name="_newMat"></param>
          void fni_setWireDefaultMat(Material _newMat);
     } 
}
