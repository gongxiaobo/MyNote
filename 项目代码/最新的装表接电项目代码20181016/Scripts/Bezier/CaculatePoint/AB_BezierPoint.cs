using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// get point on the bezier
/// </summary>
public abstract class AB_BezierPoint
{

     public abstract Vector3 fn_getPoint(Vector3[] _controlPoint, float _tpos);
     /// <summary>
     /// 获取曲线上的点，法线，旋转
     /// </summary>
     /// <param name="_controlPoint">控制点集</param>
     /// <param name="_tpos">时间位置</param>
     /// <param name="_axis">坐标朝向</param>
     /// <param name="_pos">得到的点的位置</param>
     /// <param name="_nornal">得到的点的法线</param>
     /// <param name="_rotation">得到的点的旋转</param>
     public abstract void fn_getBezierPoint(Vector3[] _controlPoint, float _tpos, Vector3 _axis, out Vector3 _pos, out Vector3 _nornal, out Quaternion _rotation);
}
