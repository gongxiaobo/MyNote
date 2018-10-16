using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
using Assets.Scripts.Tool.GetPointOnDir;
namespace Assets.Scripts.Tool.PointOnPlane
{
     /// <summary>
     /// 获取一个矩形的四点
     /// </summary>
     public static class s_rectangleOnDir
     {
          /// <summary>
          /// 在一个平面获取一个矩形的4点。
          /// </summary>
          /// <param name="_twoPoint"></param>
          /// <param name="_dir"></param>
          /// <param name="_width"></param>
          /// <returns>一个矩形的4个顺序点</returns>
          public static Vector3[] fns_getRectangle(Vector3[] _twoPoint, Vector3 _dir, float _width)
          {
               //检查方向是否可用
               if (_twoPoint == null)
               {
                    return null;
               }
               if (_twoPoint.Length != 2)
               {
                    return null;
               }
               //if (Vector3.Dot(_twoPoint[0] - _twoPoint[1], _dir) != 0)
               //{
               //     return null;
               //}
               if (_width == 0f)
               {
                    return new Vector3[4] { _twoPoint[0], _twoPoint[0], _twoPoint[1], _twoPoint[1] };
               }
               Vector3[] t_rectangle = new Vector3[4];
               t_rectangle[0] = s_getPointOnDir.fns_getPointOnDirLine(_twoPoint[0], _dir * -1f, _width);
               t_rectangle[1] = s_getPointOnDir.fns_getPointOnDirLine(_twoPoint[0], _dir, _width);
               t_rectangle[2] = s_getPointOnDir.fns_getPointOnDirLine(_twoPoint[1], _dir, _width);
               t_rectangle[3] = s_getPointOnDir.fns_getPointOnDirLine(_twoPoint[1], _dir * -1f, _width);

               return t_rectangle;

          }
     }
}
