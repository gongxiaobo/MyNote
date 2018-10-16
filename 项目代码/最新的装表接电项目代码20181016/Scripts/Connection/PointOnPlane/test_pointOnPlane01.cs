using System;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
using Assets.Scripts.Bezier.BirthMesh;
using Assets.Scripts.Tool.GetPointOnDir;
using Assets.Scripts.Tool.PointOnPlane;
using Assets.Scripts.Tool.ShowLineInEditor;
//using Assets.Scripts.Bezier.BirthMesh;
namespace Assets.Scripts.Connection.PointOnPlane
{
     /// <summary>
     /// 测试排列线
     /// 测试两点在一个平面的排序
     /// </summary>
     class test_pointOnPlane01 : MonoBehaviour
     {
          public Transform m_portA, m_portB;
          public Transform m_portA1, m_portB1;
          public Transform m_portA2, m_portB2;
          public Transform m_portA3, m_portB3;

          //public AB_ArrangeOnPlane m_arrangeOnPlane = null;
          protected AB_CaculateMode m_arrangeOnPlane = null;
          public Material m_color;
          public E_CaculateMode m_caculatemode = E_CaculateMode.e_default;
          public float m_WireR = 0.1f;
          public Vector3 m_meshAxis = new Vector3(0, 1, 0);
          void Start()
          {
               GetNormal t_normal = GetComponent<GetNormal>();
               //ShowLineInEditor.Instance.fn_PutInDot("normal_pre", new Vector3[2] { gameObject.transform.position,
               //     t_normal.fn_Normal(true)+gameObject.transform.position }, Color.yellow);
               if (m_arrangeOnPlane==null)
               {
                    m_arrangeOnPlane = GetComponent<AB_CaculateMode>();
               }

               S_BirthPipeMesh.Instance.fn_BirthPipe("test1", m_arrangeOnPlane.fnp_WireKeyPoint(m_portA.position, m_portB.position, "test1", 0.004f, m_caculatemode,0.01f),
                    0.004f, m_color, m_meshAxis);

               //Vector3 t_axis = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
               S_BirthPipeMesh.Instance.fn_BirthPipe("test2", m_arrangeOnPlane.fnp_WireKeyPoint(m_portA1.position, m_portB1.position, "test2", 0.002f, m_caculatemode),
                   0.002f, m_color, m_meshAxis);

               S_BirthPipeMesh.Instance.fn_BirthPipe("test3", m_arrangeOnPlane.fnp_WireKeyPoint(m_portA2.position, m_portB2.position, "test3", m_WireR, m_caculatemode),
                  m_WireR, m_color, m_meshAxis);

               S_BirthPipeMesh.Instance.fn_BirthPipe("test4", m_arrangeOnPlane.fnp_WireKeyPoint(m_portA3.position, m_portB3.position, "test4", m_WireR, m_caculatemode),
                 m_WireR, m_color, m_meshAxis);

          }
          //protected Vector3[] fnpArrangeStyle1(Vector3 _start, Vector3 _normal, float _NormalMoveDis, Vector3 _forward, float _forwardMoveDis)
          //{
          //     if (Vector3.Dot(gameObject.transform.position - _start, _normal) > 0)
          //     {//同一方向
          //          //向下移动开始点
          //          Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, _normal, _NormalMoveDis);
          //          //向外移动
          //          Vector3 t_2 = s_getPointOnDir.fns_getPointOnDirLine(t_1, _forward, _forwardMoveDis);
          //          return new Vector3[2] { t_1, t_2 };
          //     }
          //     else
          //     {
          //          //向上移动开始点
          //          Vector3 t_1 = s_getPointOnDir.fns_getPointOnDirLine(_start, -1f * _normal, _NormalMoveDis);
          //          //向外移动
          //          Vector3 t_2 = s_getPointOnDir.fns_getPointOnDirLine(t_1, _forward, _forwardMoveDis);
          //          return new Vector3[2] { t_1, t_2 };
          //     }

          //     //return new Vector3[2];
          //}
          //protected Vector3[] fnp_WireKeyPoint(Vector3 _Start, Vector3 _end, string _name, float _wireR, bool _style = true,float _startDis=0.03f)
          //{
          //     if (_style)
          //     {//折线的排线方式

          //          GetNormal t_normal = GetComponent<GetNormal>();
          //          Vector3 t_project = s_pointOnPlane.fns_pointOnPlane(_Start, gameObject.transform.position, t_normal.fn_Normal(true));

          //          Vector3[] t_4 = m_arrangeOnPlane.fn_project(new Vector3[2] { _Start, _end }, _name, _wireR);
          //          float t_dis = Vector3.Distance(t_project, t_4[0]);
          //          Vector3[] t_4_1 = fnpArrangeStyle1(_Start, t_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);
          //          Vector3[] t_4_2 = fnpArrangeStyle1(_end, t_normal.fn_Normal(true), _startDis, m_arrangeOnPlane.fn_getForward(), t_dis);

          //          Vector3[] t_points3;
          //          if (t_dis != 0f)
          //          {
          //               t_points3 = new Vector3[8];
          //               t_points3[0] = _Start;
          //               t_points3[1] = t_4_1[0];
          //               t_points3[2] = t_4_1[1];

          //               t_points3[3] = t_4[0];
          //               t_points3[4] = t_4[1];

          //               t_points3[5] = t_4_2[1];
          //               t_points3[6] = t_4_2[0];

          //               t_points3[7] = _end;
          //          }
          //          else
          //          {
          //               t_points3 = new Vector3[4];
          //               t_points3[0] = _Start;
          //               t_points3[1] = t_4[0];
          //               t_points3[2] = t_4[1];
          //               t_points3[3] = _end;
          //          }
          //          return t_points3;
          //     }
          //     else
          //     {//普通的排序方式
          //          Vector3[] t_4 = m_arrangeOnPlane.fn_project(new Vector3[2] { _Start, _end }, _name, _wireR);
          //          Vector3[] t_points3 = new Vector3[4];
          //          t_points3[0] = _Start;
          //          t_points3[1] = t_4[0];
          //          t_points3[2] = t_4[1];
          //          t_points3[3] = _end;
          //          return t_points3;
          //     }


          //}



     }
}
