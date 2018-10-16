using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh;
using Assets.Scripts.Tool.GetPointOnDir;
using Assets.Scripts.Tool.PointOnPlane;
using Assets.Scripts.Tool.ShowLineInEditor;
using Assets.Scripts.Bezier.BirthMesh;
using Assets.Scripts.Connection.SelectUI.RopePara;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 两点在一个平面上的投影后，按照移动方向排序后得到从上到下的关键点序列
     /// </summary>
     public class N_CaculateMode : AB_CaculateMode
     {
          public AB_ArrangeOnPlane m_arrangeOnPlane = null;
          protected GetNormal m_normal;

          public override Vector3[] fnp_WireKeyPoint(Vector3 _Start, Vector3 _end, string _name, float _wireR, E_CaculateMode _style = E_CaculateMode.e_default, float _startDis = 0.03f)
          {
               if (m_arrangeOnPlane == null)
               {
                    m_arrangeOnPlane = GetComponent<AB_ArrangeOnPlane>();
               }
               if (m_arrangeOnPlane == null)
               {
                    return null;
               }

               float t_r = _wireR;
               t_r = t_r >= RopeParaSetting.m_RopeSize.y ? RopeParaSetting.m_RopeSize.y : t_r;
               t_r = t_r <= RopeParaSetting.m_RopeSize.x ? RopeParaSetting.m_RopeSize.x : t_r;

               if (_style== E_CaculateMode.e_style2)
               {//折线的排线方式

                    if (m_normal == null)
                    {
                         m_normal = GetComponent<GetNormal>();
                         if (m_normal == null)
                         {
                              return null;
                         }
                    }
                    Vector3 t_project = s_pointOnPlane.fns_pointOnPlane(_Start, gameObject.transform.position, m_normal.fn_Normal(true));

                    Vector3[] t_4 = m_arrangeOnPlane.fn_project(new Vector3[2] { _Start, _end }, _name, t_r);
                    float t_dis = Vector3.Distance(t_project, t_4[0]);
                    Vector3[] t_4_1 = fnpArrangeStyle1(_Start, m_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);
                    Vector3[] t_4_2 = fnpArrangeStyle1(_end, m_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);

                    Vector3[] t_points3;
                    if (t_dis > 4f * t_r)
                    {//如果移动出的距离小于两个管道半径，那么就不执行移动点的计算，因为点挨的太紧
                         t_points3 = new Vector3[8];
                         t_points3[0] = _Start;
                         t_points3[1] = t_4_1[0];
                         t_points3[2] = t_4_1[1];

                         t_points3[3] = t_4[0];
                         t_points3[4] = t_4[1];

                         t_points3[5] = t_4_2[1];
                         t_points3[6] = t_4_2[0];

                         t_points3[7] = _end;
                    }
                    else
                    {
                         t_points3 = new Vector3[4];
                         t_points3[0] = _Start;
                         t_points3[1] = t_4[0];
                         t_points3[2] = t_4[1];
                         t_points3[3] = _end;
                    }
                    return t_points3;
               }
               else if (_style== E_CaculateMode.e_default)
               {
                    //普通的排序方式
                    Vector3[] t_4 = m_arrangeOnPlane.fn_project(new Vector3[2] { _Start, _end }, _name, t_r);
                    Vector3[] t_points3 = new Vector3[4];
                    t_points3[0] = _Start;
                    t_points3[1] = t_4[0];
                    t_points3[2] = t_4[1];
                    t_points3[3] = _end;
                    return t_points3;
               }
               else if (_style== E_CaculateMode.e_style1)
               {
                    if (m_normal == null)
                    {
                         m_normal = GetComponent<GetNormal>();
                         if (m_normal == null)
                         {
                              return null;
                         }
                    }
                    Vector3 t_project = s_pointOnPlane.fns_pointOnPlane(_Start, gameObject.transform.position, m_normal.fn_Normal(true));

                    Vector3[] t_4 = m_arrangeOnPlane.fn_project(new Vector3[2] { _Start, _end }, _name, t_r);
                    float t_dis = Vector3.Distance(t_project, t_4[0]);
                    Vector3 t_4_1 = fnp_ArangeStyle2(_Start, m_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);
                    Vector3 t_4_2 = fnp_ArangeStyle2(_end, m_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);

                    Vector3[] t_points3;
                    if (_startDis >= 2f * t_r)
                    {
                         t_points3 = new Vector3[6];
                         t_points3[0] = _Start;
                         t_points3[1] = t_4_1;

                         t_points3[2] = t_4[0];
                         t_points3[3] = t_4[1];

                         t_points3[4] = t_4_2;

                         t_points3[5] = _end;
                    }
                    else
                    {
                         t_points3 = new Vector3[4];
                         t_points3[0] = _Start;
                         t_points3[1] = t_4[0];
                         t_points3[2] = t_4[1];
                         t_points3[3] = _end;
                    }
                    return t_points3;
               }

               return null;
          }
         
          protected Vector3[] fnpArrangeStyle1(Vector3 _start, Vector3 _normal, float _NormalMoveDis, Vector3 _forward, float _forwardMoveDis)
          {
               if (Vector3.Dot(gameObject.transform.position - _start, _normal) > 0)
               {//同一方向
                    //向下移动开始点
                    Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, _normal, _NormalMoveDis);
                    //向外移动
                    Vector3 t_2 = s_getPointOnDir.fns_getPointOnDirLine(t_1, _forward, _forwardMoveDis);
                    return new Vector3[2] { t_1, t_2 };
               }
               else
               {
                    //向上移动开始点
                    Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, -1f * _normal, _NormalMoveDis);
                    //向外移动
                    Vector3 t_2 = s_getPointOnDir.fns_getPointOnDirLine(t_1, _forward, _forwardMoveDis);
                    return new Vector3[2] { t_1, t_2 };
               }

               //return new Vector3[2];
          }
          protected Vector3 fnp_ArangeStyle2(Vector3 _start, Vector3 _normal, float _NormalMoveDis, Vector3 _forward, float _forwardMoveDis)
          {
               if (Vector3.Dot(gameObject.transform.position - _start, _normal) > 0)
               {//同一方向
                    //向下移动开始点
                    Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, _normal, _NormalMoveDis);
                   
                    return t_1;
               }
               else
               {
                    //向上移动开始点
                    Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, -1f * _normal, _NormalMoveDis);

                    return t_1;
               }
          }

          
     }
}
