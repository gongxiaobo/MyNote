using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 计算点的模式，这是两点在一个平面上的点的计算方式
     /// </summary>
     public abstract class AB_CaculateMode:MonoBehaviour
     {
          /// <summary>
          /// 获取两点在一个平面上的排列点，包括两种排量方式
          /// </summary>
          /// <param name="_Start">开始点</param>
          /// <param name="_end">结束点</param>
          /// <param name="_name">线名称，排序需要使用</param>
          /// <param name="_wireR">线半径，主要用于投影在平面的矩形面积</param>
          /// <param name="_style">线的链接方式</param>
          /// <param name="_startDis">在第二种链接方式的第二个点离第一点的距离</param>
          /// <returns>返回这两连线间的所有关键点数组</returns>
          public abstract Vector3[] fnp_WireKeyPoint(Vector3 _Start, Vector3 _end, string _name, float _wireR, E_CaculateMode _style = E_CaculateMode.e_default, float _startDis = 0.03f);

     }
}
