using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.PointOnPlane;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 适合两点在一个平面上的投影
     /// 
     /// </summary>
     public class N_Plane_3:N_Plane
     {
          public override Vector3[] fn_project(Vector3[] _points, string _wireName, float _wireR = 0.0025f)
          {
               if (_points == null)
               {
                    return null;
               }
               if (_points.Length > 2)
               {
                    return null;
               }
               if (m_PlaneStyle != E_PlaneStyle.e_2IN2OUT)
               {//如果不是2点投影得到2点的情况
                    return null;
               }
               
               //
               if (m_rectangles.ContainsKey(_wireName))
               {
                    return null;
               }
               //把点投射到平面
               m_newPro_0 = s_pointOnPlane.fns_pointOnPlane(_points[0], M_this.position, fn_getNormal());
               m_newPro_1 = s_pointOnPlane.fns_pointOnPlane(_points[1], M_this.position, fn_getNormal());

               fnp_2pLineNotStand();

               Vector3[] t_return = new Vector3[2] { m_newPro_0, m_newPro_1 };
               if (m_Arrange == false)
               {//如果不排序，直接返回值
                    if (Vector3.Distance(m_newPro_0, m_newPro_1) <= _wireR * 4f)
                    {//两点太近,就传两点的中心点
                         return new Vector3[1] { Vector3.Lerp(m_newPro_0, m_newPro_1, 0.5f) };
                    }
                    return t_return;
               }
               else
               {//排序处理
                    //根据宽度计算一个矩形
                    Vector3[] t_rectangle = s_rectangleOnDir.fns_getRectangle(t_return, fn_getForward(), _wireR);
                    //和已经存在的矩形排序处理
                    fnp_findPos(ref t_rectangle);
                    //计算好位置后保存位置，新建区域
                    m_rectangles.Add(_wireName, new N_Rectangle());
                    t_return = new Vector3[2] { m_newPro_0, m_newPro_1 };
                    m_rectangles[_wireName].fn_putIn2Point(t_return);
                    m_rectangles[_wireName].fn_putIn4Point(t_rectangle);
                    if (Vector3.Distance(m_newPro_0,m_newPro_1)<=_wireR*4f)
                    {//两点太近,就传两点的中心点
                         return new Vector3[1] { Vector3.Lerp(m_newPro_0, m_newPro_1, 0.5f) };
                    }
                    return t_return;
               }


          }

     }
}
