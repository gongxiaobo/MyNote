using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bezier.BirthMesh.MyInterface
{
     /// <summary>
     /// 设置线的粗细和颜色
     /// </summary>
     public interface I_PutSizeAndColor
     {
          /// <summary>
          /// 设置线的颜色和粗细
          /// </summary>
          /// <param name="_size"></param>
          /// <param name="_color"></param>
          void fni_PutSizeColor(float _size, Material _color);

     }
}
