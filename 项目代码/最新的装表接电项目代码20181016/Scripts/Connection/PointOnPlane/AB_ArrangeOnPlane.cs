using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using UnityEngine;

namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 投影平面的管理类
     /// </summary>
     public abstract class AB_ArrangeOnPlane : MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 平面的法线
          /// </summary>
          /// <returns></returns>
          public abstract Vector3 fn_getNormal();
          /// <summary>
          /// 平面的排列方向
          /// </summary>
          /// <returns></returns>
          public abstract Vector3 fn_getForward();
          /// <summary>
          /// 投射点输入后计算得到在平面上合适位置的点
          /// </summary>
          /// <param name="_points">向平面投射的点</param>
          /// <param name="_name">链接线名称</param>
          /// <param name="_width">线段占地宽度</param>
          /// <returns></returns>
          public abstract Vector3[] fn_project(Vector3[] _points, string _name, float _width = 0.0025f);
          /// <summary>
          /// 计算没有使用的区域来放入新的矩形区域
          /// </summary>
          protected abstract void fnp_findPos(ref Vector3[] _rec);
          /// <summary>
          /// 移除一个矩形区域
          /// </summary>
          /// <param name="_pipename"></param>
          public abstract void fn_remove(string _pipename);
          public bool m_Arrange = true;

     }
}
