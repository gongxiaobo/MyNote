using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 电线的颜色选择变换
     /// </summary>
     public abstract class AB_WireMat : MonoBehaviour
     {
          /// <summary>
          /// 改变线的颜色
          /// </summary>
          /// <param name="_colorName"></param>
          public abstract void fn_setMaterial(string _colorName);
     } 
}
