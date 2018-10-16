using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 矩形的信息
     /// </summary>
     public abstract class AB_Rectangle
     {
          /// <summary>
          /// 放入矩形的4个顶点
          /// </summary>
          /// <param name="_rec"></param>
          public abstract void fn_putIn4Point(Vector3[] _rec);
          /// <summary>
          /// 获取矩形的4个顶点
          /// </summary>
          /// <returns></returns>
          public abstract Vector3[] fn_get4Point();
          /// <summary>
          /// 放入关键点位置
          /// </summary>
          /// <param name="_key"></param>
          public abstract void fn_putIn2Point(Vector3[] _key);
          /// <summary>
          /// 获取关键点位置
          /// </summary>
          /// <returns></returns>
          public abstract Vector3[] fn_get2Point();


     }
}
