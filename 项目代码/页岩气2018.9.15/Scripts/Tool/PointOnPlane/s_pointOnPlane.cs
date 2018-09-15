using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Tool.PointOnPlane
{
     /// <summary>
     /// 计算点再平面的投影点
     /// </summary>
     public static class s_pointOnPlane
     {
          /// <summary>
          /// 一个点在一个平面上的投影点，世界坐标
          /// </summary>
          /// <param name="_project">开始投影点</param>
          /// <param name="_plane">投影的平面原点</param>
          /// <param name="_planeNormal">投影平面的法线</param>
          /// <returns>投影点</returns>
          public static Vector3 fns_pointOnPlane(Vector3 _project, Vector3 _plane, Vector3 _planeNormal)
          {
               Vector3 t_pro = _project - _plane;
               Vector3 t_projectOnplane=Vector3.ProjectOnPlane(t_pro,_planeNormal);
               return t_projectOnplane + _plane;
          }
     }
}
