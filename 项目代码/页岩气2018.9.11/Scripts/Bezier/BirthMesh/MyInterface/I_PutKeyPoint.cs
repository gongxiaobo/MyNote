using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Bezier.BirthMesh.MyInterface
{
     /// <summary>
     /// 生成管道模型
     /// </summary>
     public interface I_PutKeyPoint
     {
          /// <summary>
          /// 放入点序列
          /// </summary>
          /// <param name="_keys">世界坐标</param>
          void fni_putKeyPoint(Vector3[] _keys);
     }
}
