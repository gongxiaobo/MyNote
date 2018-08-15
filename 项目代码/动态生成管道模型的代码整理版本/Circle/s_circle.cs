using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 计算圆上的点
/// </summary>
public static class s_circle  {
     /// <summary>
     /// 找到一个圆上的一个点
     /// 从方向a朝向方向b开始计算，
     /// </summary>
     /// <param name="_center">圆心</param>
     /// <param name="_a">圆平面的单位向量</param>
     /// <param name="_b">圆平面的单位向量</param>
     /// <param name="_radius">圆半径</param>
     /// <param name="_radian">弧度值</param>
     /// <returns></returns>
     public static Vector3 fns_getPoint(Vector3 _center,Vector3 _a,Vector3 _b, 
          float _radius, float _radian)
     {
          Vector3 circleXYZ;
          float t_sin = Mathf.Sin(_radian);
          float t_cos = Mathf.Cos(_radian);
          circleXYZ.x = _center.x + _radius * t_cos * _a.x +
              _radius * t_sin * _b.x;
          circleXYZ.y = _center.y + _radius * t_cos * _a.y +
               _radius * t_sin * _b.y;
          circleXYZ.z = _center.z + _radius * t_cos * _a.z +
               _radius * t_sin * _b.z;
          return circleXYZ;
     }
}
