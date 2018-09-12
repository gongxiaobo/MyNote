using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Tool.GetPointOnDir
{
     /// <summary>
     /// 在一个单位方向上移动一段距离后的点
     /// </summary>
     public static class s_getPointOnDir
     {
          /// <summary>
          /// 一个点在一个方向上移动一个单位距离后的点
          /// </summary>
          /// <param name="_start">开始点</param>
          /// <param name="_dir">方向单位向量</param>
          /// <returns>新的点</returns>
          public static Vector3 fns_getPointOnDirLine(Vector3 _start, Vector3 _dir,float _distance=1f)
          {
               return _start + (_dir * _distance);
               //return Vector3.zero;
          }
          /// <summary>
          /// 把一系列的点沿着一个方向移动
          /// </summary>
          /// <param name="_starts"></param>
          /// <param name="_movePoints"></param>
          /// <param name="_dir"></param>
          /// <param name="_distance"></param>
          public static void fns_MovePointOnDir(Vector3[] _starts ,out Vector3[] _movePoints, Vector3 _dir, float _distance = 1f)
          {
               Vector3[] t_new = new Vector3[_starts.Length];
               for (int i = 0; i < _starts.Length; i++)
               {
                    t_new[i] = fns_getPointOnDirLine(_starts[i], _dir, _distance);
               }
               _movePoints = t_new;
          }
          /// <summary>
          /// 把一系列的点沿着一个方向移动
          /// </summary>
          /// <param name="_starts"></param>
          /// <param name="_dir"></param>
          /// <param name="_distance"></param>
          public static void fns_MovePointOnDir(ref Vector3[] _starts, Vector3 _dir, float _distance = 1f)
          {
               for (int i = 0; i < _starts.Length; i++)
               {
                    _starts[i] = fns_getPointOnDirLine(_starts[i], _dir, _distance);
               }
          }
     }
}
