using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 装表接电中投影平面,输入一个或者两点，然后得到一个或者两个新的点
     /// </summary>
     public abstract class AB_Plane:MonoBehaviour
     {
          protected virtual void Start() { }
          /// <summary>
          /// 平面属于哪个柜体
          /// </summary>
          public E_CabinetName m_belongToCabinet = E_CabinetName.e_cabinet0;
          /// <summary>
          /// 平面的名称
          /// </summary>
          public E_PlaneName m_PlaneName = E_PlaneName.e_plane_0;
          /// <summary>
          /// 平面投影的类型
          /// </summary>
          public E_PlaneStyle m_PlaneStyle = E_PlaneStyle.e_1IN1OUT;
          /// <summary>
          /// 是否包含子平面
          /// </summary>
          public E_PlaneName m_childPlane = E_PlaneName.e_plane_0;
          /// <summary>
          /// 获取平面法线
          /// </summary>
          /// <returns>单位法线</returns>
          public abstract Vector3 fn_getNormal();
          /// <summary>
          /// 获取平面的前进方向
          /// </summary>
          /// <returns>单位向量</returns>
          public abstract Vector3 fn_getForward();
          /// <summary>
          /// 是否排序
          /// </summary>
          public bool m_Arrange = true;
          /// <summary>
          /// 有线删除时，如果这条线在这个平面排序，那么删掉这个排序矩形
          /// </summary>
          /// <param name="_wireName">链接线的名称</param>
          public abstract void fn_WireRomoved(string _wireName);
          /// <summary>
          /// 把一点或者两点投影到平面上得到新的点
          /// </summary>
          /// <param name="_points">一点或者两点</param>
          /// <param name="_wireName">连线的名称，必须唯一</param>
          /// <param name="_wireR">线的半径,用于计算矩形</param>
          /// <returns></returns>
          public abstract Vector3[] fn_project(Vector3[] _points, string _wireName, float _wireR = 0.0025f);
          /// <summary>
          /// 计算没有使用的区域来放入新的矩形区域
          /// 新加入平面的矩形找到合适位置
          /// </summary>
          protected abstract void fnp_findPos(ref Vector3[] _rec);
     }
}
