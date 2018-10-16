//using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.PointOnPlane;
using Assets.Scripts.Tool.GetPointOnDir;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 实现一个点投影，得到一个点的投影类型
     /// 可供 e_1IN1OUT ，e_child_1IN1OUT类型平面使用
     /// 添加排序功能
     /// </summary>
     public class N_Plane_1 : N_Plane
     {
          protected override void Start()
          {
               base.Start();
               if (m_PlaneStyle!= E_PlaneStyle.e_1IN1OUT || m_PlaneStyle!= E_PlaneStyle.e_child_1IN1OUT)
               {
                    m_PlaneStyle = E_PlaneStyle.e_1IN1OUT;
               }
          }
          public override Vector3[] fn_project(Vector3[] _points, string _wireName, float _wireR = 0.0025f)
          {
               if (_points==null)
               {
                    return null;
               }
               if (_points.Length>2)
               {
                    return null;
               }
               //return base.fn_project(_points, _wireName, _wireR);
               if (m_PlaneStyle != E_PlaneStyle.e_1IN1OUT && m_PlaneStyle!=E_PlaneStyle.e_child_1IN1OUT)
               {//如果不是1点投影得到1点的情况
                    return null;
               }
               //
               if (m_rectangles.ContainsKey(_wireName))
               {
                    return null;
               }
               if (m_Arrange==false)
               {//不排序的情况
                    //把点投射到平面
                    m_newPro_0 = s_pointOnPlane.fns_pointOnPlane(_points[0], M_this.position, fn_getNormal());
                    return new Vector3[1] { m_newPro_0 };
               }
               else
               {//一个点排序的情况,需要根据一个点计算出一个矩形
                    Vector3 tproject = s_pointOnPlane.fns_pointOnPlane(_points[0], M_this.position, fn_getNormal());
                    //计算两点
                    Vector3 tBinormal = Vector3.Cross(fn_getNormal(), fn_getForward());
                    //把一个点按照直径生成两点
                    m_newPro_0 = s_getPointOnDir.fns_getPointOnDirLine(tproject, tBinormal, _wireR * 2f);
                    m_newPro_1 = s_getPointOnDir.fns_getPointOnDirLine(tproject, -1f * tBinormal, _wireR * 2f);
                    Vector3[] t_return = new Vector3[2] { m_newPro_0, m_newPro_1};
                    //根据宽度计算一个矩形
                    Vector3[] t_rectangle = s_rectangleOnDir.fns_getRectangle(t_return, fn_getForward(), _wireR);
                    //和已经存在的矩形排序处理
                    fnp_findPos(ref t_rectangle);
                    //计算好位置后保存位置，新建区域
                    m_rectangles.Add(_wireName, new N_Rectangle());
                    t_return = new Vector3[2] { m_newPro_0, m_newPro_1 };
                    m_rectangles[_wireName].fn_putIn2Point(t_return);
                    m_rectangles[_wireName].fn_putIn4Point(t_rectangle);

                    return new Vector3[1] { Vector3.Lerp(m_newPro_0, m_newPro_1, 0.5f) };
               }
          }
          protected override void fnp_findPos(ref Vector3[] _rec)
          {
               base.fnp_findPos(ref _rec);
          }
     }
}
