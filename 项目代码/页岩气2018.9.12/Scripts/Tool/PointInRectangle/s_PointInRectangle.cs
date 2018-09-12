using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Tool.PointInRectangle
{
     /// <summary>
     /// 判断一个点是否在矩形内部
     /// 判断矩形是否相交
     /// </summary>
     public static class s_PointInRectangle
     {
          /// <summary>
          /// 判断一个点是否在一个矩形内部
          /// </summary>
          /// <param name="_rectangle">矩形数组，需要按照一定顺序放入点</param>
          /// <param name="_point">判断点</param>
          /// <param name="_boundary">是否包含边界 true 为包含边界</param>
          /// <returns>true为在指定矩形内部</returns>
          public static bool fns_InRectangle(Vector3[] _rectangle, Vector3 _point, bool _boundary = true)
          {
               //bool t_result = false;
               if (_rectangle == null)
               {
                    return false;
               }
               if (_rectangle.Length != 4)
               {
                    return false;
               }
               float t1 = Vector3.Dot(Vector3.Cross(_rectangle[1] - _rectangle[0], _point - _rectangle[0]),
                    Vector3.Cross(_rectangle[3] - _rectangle[2], _point - _rectangle[2]));

               float t2 = Vector3.Dot(Vector3.Cross(_rectangle[2] - _rectangle[1], _point - _rectangle[1]),
                    Vector3.Cross(_rectangle[0] - _rectangle[3], _point - _rectangle[3]));
               if (_boundary)
               {//包括边界
                    if (t1 >= 0 && t2 >= 0)
                    {//在内部
                         return true;
                    }
                    else
                    {//在外部
                         return false;
                    }
               }
               else
               {
                    if (t1 > 0 && t2 > 0)
                    {//在内部
                         return true;
                    }
                    else
                    {//在外部
                         return false;
                    }
               }


          }
          /// <summary>
          /// 判断两矩形是否相交的方法之一，
          /// 根据实际情况做了默认修改,不适合任何情况的矩形相交判断
          /// </summary>
          /// <param name="_rect1">矩形1</param>
          /// <param name="_rect2">矩形2</param>
          /// <param name="_moveDis">为了不相交需要移动的距离</param>
          /// <param name="_boundary">是否包含边界,true为边界紧挨</param>
          /// <returns>真为相交</returns>
          public static bool fns_RectInter(Vector3[] _rect1, Vector3[] _rect2, out float _moveDis, bool _boundary = true, float _offset = 0.01f)
          {
               //找到两个矩阵中心点
               Vector3 t_rectCenter1 = Vector3.Lerp(_rect1[1], _rect1[3], 0.5f);
               Vector3 t_rectCenter2 = Vector3.Lerp(_rect2[1], _rect2[3], 0.5f);
               Vector3 t_twoCenter = t_rectCenter1 - t_rectCenter2;
               //在一侧的投影长度
               float t_width = Vector3.Distance(_rect1[0], _rect1[1]) * 0.5f + Vector3.Distance(_rect2[0], _rect2[1]) * 0.5f;
               float t_project1 = Vector3.Magnitude(Vector3.Project(t_twoCenter, (_rect1[0] - _rect1[1]).normalized));
               //在另外一侧的长度
               float t_height = Vector3.Distance(_rect1[1], _rect1[2]) * 0.5f + Vector3.Distance(_rect2[1], _rect2[2]) * 0.5f;
               float t_project2 = Vector3.Magnitude(Vector3.Project(t_twoCenter, (_rect1[1] - _rect1[2]).normalized));
               //这个距离可以作为移动矩形向外后不相交的距离
               float t_widthDis = t_width - t_project1;
               if (!_boundary)
               {
                    if (t_widthDis >= 0f && t_height >= t_project2)
                    {//两矩形相交
                         _moveDis = t_widthDis + t_widthDis * _offset;
                         return true;
                    }
                    else
                    {

                         _moveDis = 0f;
                         return false;
                    }
               }
               else
               {
                    if (t_widthDis > 0f && t_height > t_project2)
                    {//两矩形相交
                         _moveDis = t_widthDis+0.00001f;
                         return true;
                    }
                    else
                    {

                         _moveDis = 0f;
                         return false;
                    }
               }
          }

     }
}
