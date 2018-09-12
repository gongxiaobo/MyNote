//using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Tool.PointOnPlane;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 实现一个点投影，得到一个点的投影类型
     /// 可供 e_1IN1OUT ，e_child_1IN1OUT类型平面使用
     /// </summary>
     public class N_Plane_1 : N_Plane
     {
         
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
               //把点投射到平面
               m_newPro_0 = s_pointOnPlane.fns_pointOnPlane(_points[0], M_this.position, fn_getNormal());
               return new Vector3[1] { m_newPro_0 };
          }
          protected override void fnp_findPos(ref Vector3[] _rec)
          {
               base.fnp_findPos(ref _rec);
          }
     }
}
