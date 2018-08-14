using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 曲线的静态计算类
/// </summary>
public static class S_BezierTool
{

     public static Vector3 fnp_VectorLerp(Vector3 _p0, Vector3 _p1, float _t)
     {
          return (1f - _t) * _p0 + _t * _p1;
     }
}
